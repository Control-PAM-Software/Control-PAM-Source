using Control.Logic;

namespace Control.Tests.Parsing;

public class DateParsingTests
{
    private static DateOnly ApplyBusinessRule(DateTime dt)
        => DateOnly.FromDateTime(dt.Year < DateTime.Today.Year ? dt.AddYears(100) : dt);

    [Fact]
    public void NormalizeTwoDigitYearDate_FromDateTime_KeepsFutureDate()
    {
        var result = Functions.NormalizeTwoDigitYearDate(new DateTime(2099, 5, 5));

        Assert.Equal(new DateOnly(2099, 5, 5), result);
    }

    [Fact]
    public void NormalizeTwoDigitYearDate_FromOADate()
    {
        var dt = new DateTime(2099, 12, 31);
        var result = Functions.NormalizeTwoDigitYearDate(dt.ToOADate());

        Assert.Equal(new DateOnly(2099, 12, 31), result);
    }

    [Theory]
    [InlineData("30/06/2099", 2099, 6, 30)]
    [InlineData("17/11/30", 2030, 11, 17)]
    [InlineData("15/05/2032", 2032, 5, 15)]
    [InlineData("01/1/2030", 2030, 1, 1)] // día con 2 dígitos, mes con 1
    [InlineData("05/13/2030", 2030, 5, 13)] // formato MM/dd/yyyy
    [InlineData("31/12/99", 2099, 12, 31)]
    public void NormalizeTwoDigitYearDate_FromString(string value, int year, int month, int day)
    {
        var result = Functions.NormalizeTwoDigitYearDate(value);

        Assert.Equal(new DateOnly(year, month, day), result);
    }

    [Fact]
    public void NormalizeTwoDigitYearDate_DateTimeWithTime_KeepsDateOnly()
    {
        var result = Functions.NormalizeTwoDigitYearDate(new DateTime(2099, 5, 5, 23, 59, 59));

        Assert.Equal(new DateOnly(2099, 5, 5), result);
    }

    [Fact]
    public void NormalizeTwoDigitYearDate_NumericString_ThrowsFromOADate()
    {
        // "20300101" es parseado como OADate -> supera el rango DateTime -> lanza
        Assert.Throws<ArgumentException>(() => Functions.NormalizeTwoDigitYearDate("20300101"));
    }

    [Fact]
    public void NormalizeTwoDigitYearDate_PastYear_RollsForwardOneCentury()
    {
        var past = new DateTime(2001, 1, 1);
        var result = Functions.NormalizeTwoDigitYearDate(past);

        Assert.Equal(ApplyBusinessRule(past), result);
    }

    [Fact]
    public void NormalizeTwoDigitYearDate_CurrentYear_NotRolled()
    {
        var today = DateTime.Today;
        var result = Functions.NormalizeTwoDigitYearDate(today);

        Assert.Equal(DateOnly.FromDateTime(today), result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("not-a-date")]
    public void NormalizeTwoDigitYearDate_Invalid_ReturnsNull(object value)
    {
        Assert.Null(Functions.NormalizeTwoDigitYearDate(value));
    }

    [Fact]
    public void NormalizeTwoDigitYearDate_WhitespaceString_ReturnsNull()
    {
        Assert.Null(Functions.NormalizeTwoDigitYearDate("   "));
    }

    [Fact]
    public void ConvertDate_FormatsAsDdMmYyyy()
    {
        Assert.Equal("01/01/2030", Functions.ConvertDate("300101"));
    }

    [Theory]
    [InlineData("")]
    [InlineData("290229")]
    [InlineData("abc")]
    public void ConvertDate_Invalid_ReturnsEmpty(string value)
    {
        Assert.Equal("", Functions.ConvertDate(value));
    }

    [Fact]
    public void ConvertDate_Null_ReturnsEmpty()
    {
        Assert.Equal("", Functions.ConvertDate(null!));
    }

    [Fact]
    public void ConvertDate_CustomFormat()
    {
        Assert.Equal("01/01/2030", Functions.ConvertDate("01/01/2030", "dd/MM/yyyy"));
    }
}
