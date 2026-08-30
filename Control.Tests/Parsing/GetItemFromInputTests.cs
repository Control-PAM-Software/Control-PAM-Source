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

    [Fact]
    public void GetItemFromInputAtos_RealQrWithDollar_ParsesGs1()
    {
        // QR real del Issue #28 (49 chars, incluye el separador '$' de la lectora)
        string input = "01073317910058931125090117280831102509072$2407290";

        var item = Functions.GetItemFromInputAtos(input);

        Assert.NotNull(item);
        Assert.Equal("7290", item.CodItem);
        Assert.Equal("2509072", item.SerialNumber);
        Assert.Equal(1, item.Quantity);
        Assert.Equal("31/08/2028", item.DueDate);
    }

    [Fact]
    public void GetItemFromInputAtos_RealQrWithoutDollar_ParsesGs1()
    {
        // Mismo QR sin el separador '$' (48 chars)
        string input = "010733179100589311250901172808311025090722407290";

        var item = Functions.GetItemFromInputAtos(input);

        Assert.NotNull(item);
        Assert.Equal("7290", item.CodItem);
        Assert.Equal("2509072", item.SerialNumber);
        Assert.Equal(1, item.Quantity);
        Assert.Equal("31/08/2028", item.DueDate);
    }

    [Fact]
    public void GetItemFromInputAtos_Gs1InvalidDate_ReturnsNull()
    {
        // Estructura GS1 válida pero fecha de vencimiento inválida (99/99)
        string input = "010733179100589311250901179999991025090722407290";

        Assert.Null(Functions.GetItemFromInputAtos(input));
    }

    [Fact]
    public void GetItemFromInputAtos_NullOrEmpty_ReturnsNull()
    {
        Assert.Null(Functions.GetItemFromInputAtos(null));
        Assert.Null(Functions.GetItemFromInputAtos(""));
        Assert.Null(Functions.GetItemFromInputAtos("   "));
        Assert.Null(Functions.GetItemFromInputAtos("abc"));
    }

    private static string BuildAtosGs1(string gtin, string vto, string lot, string codigo,
        string separador = "")
    {
        string s = separador;
        return $"01{gtin}{s}11{s}250901{s}17{s}{vto}{s}10{s}{lot}{s}240{s}{codigo}";
    }

    [Theory]
    [InlineData(";")]
    [InlineData("$")]
    [InlineData("/")]
    [InlineData(" ")]
    public void GetItemFromInputAtos_Gs1UnusualSeparators_AreSanitized(string sep)
    {
        // El separador GS1 puede variar según la lectora (la sanita antes de matchear)
        string input = BuildAtosGs1("07331791005893", "280831", "2509072", "7290", sep);

        var item = Functions.GetItemFromInputAtos(input);

        Assert.NotNull(item);
        Assert.Equal("7290", item.CodItem);
        Assert.Equal("2509072", item.SerialNumber);
        Assert.Equal("31/08/2028", item.DueDate);
    }

    [Fact]
    public void GetItemFromInputAtos_Gs1GroupSeparatorControlChar_IsSanitized()
    {
        // Separador de grupo GS1 estándar (FNC1) emitido como carácter de control \u001D
        string input = BuildAtosGs1("07331791005893", "280831", "2509072", "7290", "\u001D");

        var item = Functions.GetItemFromInputAtos(input);

        Assert.NotNull(item);
        Assert.Equal("7290", item.CodItem);
        Assert.Equal("2509072", item.SerialNumber);
        Assert.Equal("31/08/2028", item.DueDate);
    }

    [Theory]
    [InlineData("25090")]   // 5 dígitos
    [InlineData("250907")]  // 6 dígitos
    [InlineData("2509072")] // 7 dígitos
    [InlineData("25090724")]// 8 dígitos
    public void GetItemFromInputAtos_Gs1VariableLotLength(string lot)
    {
        string input = BuildAtosGs1("07331791005893", "280831", lot, "7290");

        var item = Functions.GetItemFromInputAtos(input);

        Assert.NotNull(item);
        Assert.Equal("7290", item.CodItem);
        Assert.Equal(lot, item.SerialNumber);
        Assert.Equal("31/08/2028", item.DueDate);
    }

    [Theory]
    [InlineData("729")]   // 3 dígitos
    [InlineData("7290")]  // 4 dígitos
    [InlineData("72901")] // 5 dígitos
    public void GetItemFromInputAtos_Gs1VariableCodeLength(string codigo)
    {
        string input = BuildAtosGs1("07331791005893", "280831", "2509072", codigo);

        var item = Functions.GetItemFromInputAtos(input);

        Assert.NotNull(item);
        Assert.Equal(codigo, item.CodItem);
        Assert.Equal("2509072", item.SerialNumber);
        Assert.Equal("31/08/2028", item.DueDate);
    }

    [Theory]
    [InlineData("311231", "31/12/2031")] // último día del año
    [InlineData("280101", "01/01/2028")] // primer día del año
    [InlineData("300229", null)]         // 2030 no es bisiesto -> inválido
    [InlineData("240229", "29/02/2024")] // 2024 es bisiesto -> válido
    public void GetItemFromInputAtos_Gs1DateBoundaries(string vto, string expected)
    {
        string input = BuildAtosGs1("07331791005893", vto, "2509072", "7290");

        var item = Functions.GetItemFromInputAtos(input);

        if (expected == null)
        {
            Assert.Null(item);
        }
        else
        {
            Assert.NotNull(item);
            Assert.Equal(expected, item.DueDate);
        }
    }

    [Theory]
    [InlineData("01073317910058931125090117280831102509072$2407290")] // el QR del issue
    [InlineData("010733179100589311250901172808311025090722407290")]  // sin '$'
    [InlineData("010733179100589311250901171234561025090722407290")]  // otro vto
    public void GetItemFromInputAtos_NoThrowOnVariousQr(string input)
    {
        // Este bug originalmente lanzaba una excepción no controlada;
        // ahora nunca debe lanzar.
        var ex = Record.Exception(() => Functions.GetItemFromInputAtos(input));

        Assert.Null(ex);
    }

    [Fact]
    public void GetItemFromInputAtos_Gs1Code7439_With17_NoDueDate()
    {
        // El único producto Atos sin vencimiento es el 7439: aunque el QR traiga
        // el campo (17), se registra con vencimiento vacío.
        string input = BuildAtosGs1("07331791005001", "280831", "2509072", "7439");

        var item = Functions.GetItemFromInputAtos(input);

        Assert.NotNull(item);
        Assert.Equal("7439", item.CodItem);
        Assert.Equal("2509072", item.SerialNumber);
        Assert.Equal("", item.DueDate);
    }

    [Fact]
    public void GetItemFromInputAtos_Gs1Code7439_Without17_NoDueDate()
    {
        // QR GS1 de un 7439 que no incluye el campo (17) -> vencimiento vacío.
        string input = "01" + "07331791005001" + "11" + "250901" + "10" + "2509072" + "240" + "7439";

        var item = Functions.GetItemFromInputAtos(input);

        Assert.NotNull(item);
        Assert.Equal("7439", item.CodItem);
        Assert.Equal("2509072", item.SerialNumber);
        Assert.Equal("", item.DueDate);
    }

    [Fact]
    public void GetItemFromInputAtos_Gs1Code7439_Without17_WithDollar_NoDueDate()
    {
        // Mismo caso pero con el separador '$' que emite la lectora.
        string input = "01$07331791005001$11$250901$10$2509072$240$7439";

        var item = Functions.GetItemFromInputAtos(input);

        Assert.NotNull(item);
        Assert.Equal("7439", item.CodItem);
        Assert.Equal("2509072", item.SerialNumber);
        Assert.Equal("", item.DueDate);
    }

    [Fact]
    public void GetItemFromInputAtos_Gs1OtherCodeWithout17_ReturnsNull()
    {
        // Un producto distinto de 7439 requiere vencimiento (17): si no lo trae -> null.
        string input = "01" + "07331791005001" + "11" + "250901" + "10" + "2509072" + "240" + "7260";

        Assert.Null(Functions.GetItemFromInputAtos(input));
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
