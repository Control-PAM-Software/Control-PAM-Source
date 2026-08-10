using Control.Logic;
using Control.Models.Entities;

namespace Control.Tests.Parsing;

public class ReadAnexoTests
{
    private static Headers DefaultHeaders() => new Headers();

    [Fact]
    public void ReadAnexo_ParsesClipboardTable()
    {
        string anexo =
            "ArtCode\tQuantity\tDescription\tSerialNr\tDueDate\n" +
            "A1\t5\tDesc1\tSN1\t01/01/2030\n" +
            "A2\t2\tDesc2\tSN2\tNo Aplica\n";

        var items = Functions.ReadAnexo(anexo, DefaultHeaders());

        Assert.NotNull(items);
        Assert.Equal(2, items.Count);

        Assert.Equal("A1", items[0].CodItem);
        Assert.Equal(5, items[0].Quantity);
        Assert.Equal("SN1", items[0].SerialNumber);
        Assert.Equal("01/01/2030", items[0].DueDate);

        Assert.Equal("A2", items[1].CodItem);
        Assert.Equal(2, items[1].Quantity);
        Assert.Equal("", items[1].DueDate);
    }

    [Fact]
    public void ReadAnexo_GroupsIdenticalRows()
    {
        string anexo =
            "ArtCode\tQuantity\tDescription\tSerialNr\tDueDate\n" +
            "A1\t5\tD1\tSN1\t01/01/2030\n" +
            "A1\t3\tD1\tSN1\t01/01/2030\n";

        var items = Functions.ReadAnexo(anexo, DefaultHeaders());

        Assert.NotNull(items);
        Assert.Single(items);
        Assert.Equal(8, items[0].Quantity);
    }

    [Fact]
    public void ReadAnexo_SplitsSerialAtSlash()
    {
        string anexo =
            "ArtCode\tQuantity\tDescription\tSerialNr\tDueDate\n" +
            "A1\t1\tD1\tSN1/XYZ\t01/01/2030\n";

        var items = Functions.ReadAnexo(anexo, DefaultHeaders());

        Assert.NotNull(items);
        Assert.Equal("SN1", items[0].SerialNumber);
    }

    [Fact]
    public void ReadAnexo_MovementsBernafon_ParsesCodeAndQuantity()
    {
        string anexo =
            "ArtCode\tQuantity\n" +
            "B1\t3\n" +
            "B1\t2\n";

        var items = Functions.ReadAnexo(anexo, DefaultHeaders(), movementsBernafon: true);

        Assert.NotNull(items);
        Assert.Single(items);
        Assert.Equal("B1", items[0].CodItem);
        Assert.Equal(5, items[0].Quantity);
    }

    [Fact]
    public void ReadAnexo_MovementsBernafon_SkipsEmptyQuantityRows()
    {
        string anexo =
            "ArtCode\tQuantity\n" +
            "B1\t3\n" +
            "B2\t\n";

        var items = Functions.ReadAnexo(anexo, DefaultHeaders(), movementsBernafon: true);

        Assert.NotNull(items);
        Assert.Single(items);
        Assert.Equal("B1", items[0].CodItem);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void ReadAnexo_BlankInput_ReturnsNull(string input)
    {
        Assert.Null(Functions.ReadAnexo(input, DefaultHeaders()));
    }

    [Fact]
    public void ReadAnexo_GroupItemsFalse_KeepsSeparateRows()
    {
        string anexo =
            "ArtCode\tQuantity\tDescription\tSerialNr\tDueDate\n" +
            "A1\t5\tD1\tSN1\t01/01/2030\n" +
            "A1\t3\tD1\tSN1\t01/01/2030\n";

        var items = Functions.ReadAnexo(anexo, DefaultHeaders(), groupItems: false);

        Assert.NotNull(items);
        Assert.Equal(2, items.Count);
    }

    [Fact]
    public void ReadAnexo_BlankLines_Skipped()
    {
        string anexo =
            "ArtCode\tQuantity\tDescription\tSerialNr\tDueDate\n" +
            "A1\t1\tD1\tSN1\t01/01/2030\n" +
            "\n" +
            "A2\t2\tD2\tSN2\t01/01/2030\n";

        var items = Functions.ReadAnexo(anexo, DefaultHeaders());

        Assert.NotNull(items);
        Assert.Equal(2, items.Count);
    }

    [Fact]
    public void ReadAnexo_EmptyCodeRow_AddedWithEmptyCode()
    {
        string anexo =
            "ArtCode\tQuantity\tDescription\tSerialNr\tDueDate\n" +
            "\t1\tD1\tSN1\t01/01/2030\n";

        var items = Functions.ReadAnexo(anexo, DefaultHeaders());

        Assert.NotNull(items);
        Assert.Single(items);
        Assert.Equal("", items[0].CodItem);
        Assert.Equal(1, items[0].Quantity);
    }

    [Fact]
    public void ReadAnexo_MissingSerial_EmptySerial()
    {
        string anexo =
            "ArtCode\tQuantity\tDescription\tSerialNr\tDueDate\n" +
            "A1\t1\tD1\t\t01/01/2030\n";

        var items = Functions.ReadAnexo(anexo, DefaultHeaders());

        Assert.NotNull(items);
        Assert.Equal("", items[0].SerialNumber);
    }

    [Fact]
    public void ReadAnexo_MovementsBernafon_HeaderCaseInsensitive()
    {
        string anexo =
            "artcode\tquantity\n" +
            "B1\t3\n";

        var items = Functions.ReadAnexo(anexo, DefaultHeaders(), movementsBernafon: true);

        Assert.NotNull(items);
        Assert.Single(items);
        Assert.Equal("B1", items[0].CodItem);
        Assert.Equal(3, items[0].Quantity);
    }

    [Fact]
    public void ReadAnexo_MovementsBernafon_InvalidQuantityBecomesZero()
    {
        string anexo =
            "ArtCode\tQuantity\n" +
            "B1\tabc\n";

        var items = Functions.ReadAnexo(anexo, DefaultHeaders(), movementsBernafon: true);

        Assert.NotNull(items);
        Assert.Single(items);
        Assert.Equal(0, items[0].Quantity);
    }

    [Fact]
    public void ReadAnexo_TwoDigitYear_NormalizedToFutureCentury()
    {
        string anexo =
            "ArtCode\tQuantity\tDescription\tSerialNr\tDueDate\n" +
            "A1\t1\tD1\tSN1\t17/11/30\n";

        var items = Functions.ReadAnexo(anexo, DefaultHeaders());

        Assert.NotNull(items);
        Assert.Equal("17/11/2030", items[0].DueDate);
    }
}
