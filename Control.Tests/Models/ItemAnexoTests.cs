using Control.Logic;
using Control.Models.Entities;
using Control.Models.Responses;
using Control.Models.Settings;

namespace Control.Tests.Models;

public class ItemAnexoTests
{
    [Fact]
    public void Clone_CreatesIndependentCopy()
    {
        var original = new ItemAnexo("A1", "Desc", "SN1", 3, "01/01/2030");
        var clone = original.Clone();

        Assert.NotSame(original, clone);
        Assert.Equal(original.CodItem, clone.CodItem);
        Assert.Equal(original.Description, clone.Description);
        Assert.Equal(original.SerialNumber, clone.SerialNumber);
        Assert.Equal(original.Quantity, clone.Quantity);
        Assert.Equal(original.DueDate, clone.DueDate);

        clone.Quantity = 99;
        Assert.Equal(3, original.Quantity);
    }

    [Fact]
    public void DefaultConstructor_InitializesEmptyValues()
    {
        var item = new ItemAnexo();

        Assert.Equal("", item.CodItem);
        Assert.Equal("", item.Description);
        Assert.Equal("", item.SerialNumber);
        Assert.Equal(0, item.Quantity);
        Assert.Equal("", item.DueDate);
        Assert.False(item.IsAquaKit);
    }

    [Fact]
    public void GetItemAnexoReport_ReturnsReportWithZeroFisical()
    {
        var item = new ItemAnexo("A1", "Desc", "SN1", 3, "01/01/2030");

        var report = item.GetItemAnexoReport();

        Assert.Equal("A1", report.CodItem);
        Assert.Equal(3, report.Quantity);
        Assert.Equal(0, report.QuantityFisical);
        Assert.Equal(3, report.QuantityDifference);
    }

    [Fact]
    public void Report_QuantityDifference_IsQuantityMinusFisical()
    {
        var report = new ItemAnexoReport { Quantity = 10, QuantityFisical = 3 };

        Assert.Equal(7, report.QuantityDifference);
    }

    [Fact]
    public void Report_QuantityDifferenceSetter_IsIgnored()
    {
        // El setter asigna un campo muerto; el getter siempre calcula Quantity - QuantityFisical
        var report = new ItemAnexoReport { Quantity = 10, QuantityFisical = 3 };
        report.QuantityDifference = 99;

        Assert.Equal(7, report.QuantityDifference);
    }

    [Fact]
    public void Clone_DoesNotCopyAquaKitFlag()
    {
        var original = new ItemAnexo("A1", "Desc", "SN1", 3, "01/01/2030") { IsAquaKit = true };

        var clone = original.Clone();

        Assert.True(original.IsAquaKit);
        Assert.False(clone.IsAquaKit);
    }
}

public class OpenOrangeTests
{
    [Fact]
    public void CountActiveColumns_CountsOnlyActive()
    {
        var openOrange = new OpenOrange();
        openOrange.ColumnCode.isActive = true;
        openOrange.ColumnUnits.isActive = true;
        openOrange.ColumnSerialNumber.isActive = false;
        openOrange.ColumnDueDate.isActive = true;

        Assert.Equal(3, Functions.CountActiveColumns(openOrange));
    }

    [Fact]
    public void CountActiveColumns_Null_ReturnsZero()
    {
        Assert.Equal(0, Functions.CountActiveColumns(null!));
    }

    [Fact]
    public void CountActiveColumns_NullColumnProperty_NotCounted()
    {
        var openOrange = new OpenOrange();
        openOrange.ColumnCode = null!;
        openOrange.ColumnUnits.isActive = true;

        Assert.Equal(1, Functions.CountActiveColumns(openOrange));
    }
}

public class DecompressStringTests
{
    private static string Compress(string text)
    {
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(text);
        using var ms = new MemoryStream();
        using (var zip = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress))
        {
            zip.Write(buffer, 0, buffer.Length);
        }
        return Convert.ToBase64String(ms.ToArray());
    }

    [Fact]
    public void DecompressString_RoundTrips()
    {
        string original = "abc;123;SN1;01/01/2030";
        string compressed = Compress(original);

        Assert.Equal(original, Functions.DecompressString(compressed));
    }

    [Fact]
    public void DecompressString_EmptyContent_RoundTrips()
    {
        string compressed = Compress("");

        Assert.Equal("", Functions.DecompressString(compressed));
    }

    [Fact]
    public void DecompressString_InvalidBase64_Throws()
    {
        Assert.Throws<FormatException>(() => Functions.DecompressString("###not-base64###"));
    }

    [Fact]
    public void DecompressString_NotGZip_Throws()
    {
        string notGzip = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("plain text"));

        Assert.Throws<System.IO.InvalidDataException>(() => Functions.DecompressString(notGzip));
    }
}
