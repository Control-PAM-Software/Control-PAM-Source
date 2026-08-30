using Control.Logic;

namespace Control.Tests.Parsing;

public class GetItemFromInputEdgeTests
{
    [Fact]
    public void GetItemFromInputAtos_TooShort_ReturnsNull()
    {
        // Menor a 14 caracteres -> no lanza, devuelve null
        Assert.Null(Functions.GetItemFromInputAtos("abc"));
        Assert.Null(Functions.GetItemFromInputAtos(""));
        Assert.Null(Functions.GetItemFromInputAtos("   "));
    }

    [Fact]
    public void GetItemFromInputAtos_MinimalLengthWith7439_WorksWithoutDate()
    {
        // 14 chars: serie = chars 0..6, code = "7439" -> sin vencimiento
        string input = "SN12345" + "000" + "7439";

        var item = Functions.GetItemFromInputAtos(input);

        Assert.NotNull(item);
        Assert.Equal("7439", item.CodItem);
        Assert.Equal("SN12345", item.SerialNumber);
        Assert.Equal("", item.DueDate);
    }

    [Fact]
    public void GetItemFromInputAtos_ShortWithout7439_NoThrowEmptyDate()
    {
        // 14 chars pero code != 7439 y longitud < 24 -> fecha vacía, no lanza
        string input = "SN12345" + "000" + "9999";

        var item = Functions.GetItemFromInputAtos(input);

        Assert.NotNull(item);
        Assert.Equal("9999", item.CodItem);
        Assert.Equal("SN12345", item.SerialNumber);
        Assert.Equal("", item.DueDate);
    }

    [Fact]
    public void GetItemFromInputInomed_RealWorldSample_NotParsed()
    {
        // El ejemplo documentado en el código no matchea el regex actual:
        // el AI (10) aparece antes del (17), rompiendo la secuencia esperada.
        string input = "01142503076038452405326251024D029D172904043010";

        Assert.Null(Functions.GetItemFromInputInomed(input));
    }

    [Fact]
    public void GetItemFromInputOticom_SerialStarts21_Stripped()
    {
        var item = Functions.GetItemFromInputOticom("0000123456", "21SN123");

        Assert.NotNull(item);
        Assert.Equal("SN123", item.SerialNumber);
    }

    [Fact]
    public void GetItemFromInputOticom_SerialOnly21_ReturnsNull()
    {
        // "21" -> Substring(2) = "" -> serial vacío -> null
        Assert.Null(Functions.GetItemFromInputOticom("0000123456", "21"));
    }

    [Fact]
    public void GetItemFromInputOticom_SerialNotMatching_ReturnsNull()
    {
        Assert.Null(Functions.GetItemFromInputOticom("NOPE", "NOPE"));
    }

    [Fact]
    public void GetItemFromInputAB_SerialLength15_NoDateExtraction()
    {
        string serial = "SN1234567890123"; // 15 chars
        Assert.Equal(15, serial.Length);

        var item = Functions.GetItemFromInputAB("COD-1", serial);

        Assert.NotNull(item);
        Assert.Equal(serial, item.SerialNumber);
        Assert.Equal("", item.DueDate);
    }

    [Fact]
    public void GetItemFromInputAB_SerialLength16_ExtractsImplantDate()
    {
        string serial = "X" + "300101" + "123456789"; // 16 chars, rawDate en 1..6
        Assert.Equal(16, serial.Length);

        var item = Functions.GetItemFromInputAB("COD-1", serial);

        Assert.NotNull(item);
        Assert.Equal("3456789", item.SerialNumber);
        Assert.Equal("01/01/2030", item.DueDate);
    }

    [Fact]
    public void GetItemFromInputAB_MultipleApostrophes_AllReplaced()
    {
        var item = Functions.GetItemFromInputAB("12'34'56", "SN1");

        Assert.Equal("12-34-56", item.CodItem);
    }

    [Fact]
    public void GetItemFromInputAB_EmptySerial_ReturnsItem()
    {
        var item = Functions.GetItemFromInputAB("COD-1", "");

        Assert.NotNull(item);
        Assert.Equal("", item.SerialNumber);
        Assert.Equal(1, item.Quantity);
    }
}
