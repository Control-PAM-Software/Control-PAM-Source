using Control.Logic;
using Control.Models.Entities;

namespace Control.Tests.Parsing;

public class GetItemFromInputTests
{
    [Fact]
    public void GetItemFromInputAtos_ExtractsCodeSerialAndDate()
    {
        // 6..11 -> "300101" (yyMMdd), last 4 chars -> code "9999", chars 14..20 -> serial
        string input = "00000030010100SN123450009999";

        var item = Functions.GetItemFromInputAtos(input);

        Assert.NotNull(item);
        Assert.Equal("9999", item.CodItem);
        Assert.Equal("SN12345", item.SerialNumber);
        Assert.Equal(1, item.Quantity);
        Assert.Equal("01/01/2030", item.DueDate);
    }

    [Fact]
    public void GetItemFromInputAtos_Code7439_NoDueDate()
    {
        // same layout but code = "7439" -> due date is skipped
        string input = "00000030010100SN123450007439";

        var item = Functions.GetItemFromInputAtos(input);

        Assert.NotNull(item);
        Assert.Equal("7439", item.CodItem);
        Assert.Equal("SN12345", item.SerialNumber);
        Assert.Equal("", item.DueDate);
    }

    [Theory]
    [InlineData("01123456789012342406543211727010110ABC123305")]
    public void GetItemFromInputInomed_ParsesGs1(string input)
    {
        var item = Functions.GetItemFromInputInomed(input);

        Assert.NotNull(item);
        Assert.Equal("654321", item.CodItem);
        Assert.Equal("ABC123", item.SerialNumber);
        Assert.Equal("01/01/2027", item.DueDate);
        Assert.Equal(5, item.Quantity);
    }

    [Theory]
    [InlineData("")]
    [InlineData("texto-sin-formato")]
    [InlineData("0112345678901234")]
    public void GetItemFromInputInomed_InvalidInput_ReturnsNull(string input)
    {
        Assert.Null(Functions.GetItemFromInputInomed(input));
    }

    [Fact]
    public void GetItemFromInputOticom_SimplePattern()
    {
        var item = Functions.GetItemFromInputOticom("0000123456", "21ABC123");

        Assert.NotNull(item);
        Assert.Equal("123456", item.CodItem);
        Assert.Equal("ABC123", item.SerialNumber);
        Assert.Equal(1, item.Quantity);
        Assert.Equal("", item.DueDate);
    }

    [Fact]
    public void GetItemFromInputOticom_Gs1Pattern()
    {
        string codeInput = "01" + "12345678901234" + "10ABCDEFGH" + "11" + "123456" + "17" + "300101" + "240" + "654321";
        string serialInput = "00001234";

        var item = Functions.GetItemFromInputOticom(codeInput, serialInput);

        Assert.NotNull(item);
        Assert.Equal("654321", item.CodItem);
        Assert.Equal("1234", item.SerialNumber);
        Assert.Equal("01/01/2030", item.DueDate);
        Assert.Equal(1, item.Quantity);
    }

    [Fact]
    public void GetItemFromInputOticom_NoMatch_ReturnsNull()
    {
        Assert.Null(Functions.GetItemFromInputOticom("no-valid", "no-valid"));
    }

    [Fact]
    public void GetItemFromInputAB_ShortSerial_UppercasesValues()
    {
        var item = Functions.GetItemFromInputAB("1234'56", "sn-1");

        Assert.NotNull(item);
        Assert.Equal("1234-56", item.CodItem);
        Assert.Equal("SN-1", item.SerialNumber);
        Assert.Equal(1, item.Quantity);
        Assert.Equal("", item.DueDate);
    }

    [Fact]
    public void GetItemFromInputAB_LongSerial_ExtractsImplantDate()
    {
        // 20 chars: rawDate at chars 5..10 = "300101", serie = last 7 = "SN12345"
        string serial = "ZZZZZ" + "300101" + "00" + "SN12345";

        var item = Functions.GetItemFromInputAB("1234-56", serial);

        Assert.NotNull(item);
        Assert.Equal("1234-56", item.CodItem);
        Assert.Equal("SN12345", item.SerialNumber);
        Assert.Equal("01/01/2030", item.DueDate);
    }

    [Fact]
    public void GetImplantDate_ReturnsSerieAndDate()
    {
        string serial = "ZZZZZ" + "300101" + "00" + "SN12345";

        var (serie, dueDate) = Functions.getImplantDate(serial);

        Assert.Equal("SN12345", serie);
        Assert.Equal("01/01/2030", dueDate);
    }

    [Fact]
    public void GetDueDate_ParsesSegment()
    {
        // chars 6..11 = "300101" -> 2030-01-01
        string input = "00000030010100SN123450009999";

        Assert.Equal("01/01/2030", Functions.GetDueDate(input));
    }

    [Fact]
    public void GetItemFromInput_DispatchByProductLine()
    {
        var atos = Functions.GetItemFromInput("00000030010100SN123450009999", eProductLine.Atos);
        Assert.NotNull(atos);

        var oticom = Functions.GetItemFromInput("0000123456", "21ABC123", eProductLine.Oticom);
        Assert.NotNull(oticom);

        var ab = Functions.GetItemFromInput("1234-56", "sn-1", eProductLine.AB);
        Assert.NotNull(ab);

        Assert.Null(Functions.GetItemFromInput("x", "y", eProductLine.Bernafon));
    }
}
