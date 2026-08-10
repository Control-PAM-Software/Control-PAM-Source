using Control.Logic;

namespace Control.Tests.Parsing;

public class QuantityAndCodeParsingTests
{
    [Theory]
    [InlineData("5", 5)]
    [InlineData("0", 0)]
    [InlineData("1.234,5", 1234)]
    [InlineData("1,5", 1)]
    [InlineData("10.000", 10000)]
    [InlineData(" 7 ", 7)]
    [InlineData("-5", -5)]
    [InlineData("1.000", 1000)]
    [InlineData("0,9", 0)]
    [InlineData("3,14", 3)]
    [InlineData("1.234.567,89", 1234567)]
    public void GetQuantityValue_ParsesSpanishFormats(string value, int expected)
    {
        Assert.Equal(expected, Functions.getQuantityValue(value));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("   ")]
    [InlineData("abc")]
    [InlineData("12,12,12")]
    public void GetQuantityValue_Invalid_ReturnsZero(string value)
    {
        Assert.Equal(0, Functions.getQuantityValue(value));
    }

    [Fact]
    public void GetQuantityValue_TruncatesNotRounds()
    {
        Assert.Equal(1, Functions.getQuantityValue("1,9999"));
    }

    [Fact]
    public void GetCodeDescriptionSplitted_SplitsAtFirstSpace()
    {
        var (cod, desc) = Functions.GetCodeDescriptionSplitted("CI-5293-130 Naida TM CI M90 Procesador de Sonido marron");

        Assert.Equal("CI-5293-130", cod);
        Assert.Equal("Naida TM CI M90 Procesador de Sonido marron", desc);
    }

    [Fact]
    public void GetCodeDescriptionSplitted_NoDescription_ReturnsEmptyDescription()
    {
        var (cod, desc) = Functions.GetCodeDescriptionSplitted("SOLOCODIGO");

        Assert.Equal("SOLOCODIGO", cod);
        Assert.Equal("", desc);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void GetCodeDescriptionSplitted_EmptyInput_ReturnsEmpty(string input)
    {
        var (cod, desc) = Functions.GetCodeDescriptionSplitted(input);

        Assert.Equal("", cod);
        Assert.Equal("", desc);
    }

    [Fact]
    public void GetCodeDescriptionSplitted_TrimsDashesAndSpacesFromDescription()
    {
        var (cod, desc) = Functions.GetCodeDescriptionSplitted("CI-5293-130 - Naida TM CI -");

        Assert.Equal("CI-5293-130", cod);
        Assert.Equal("Naida TM CI", desc);
    }

    [Fact]
    public void GetCodeDescriptionSplitted_LeadingSpace_NoSplit()
    {
        var (cod, desc) = Functions.GetCodeDescriptionSplitted(" CODE desc");

        Assert.Equal(" CODE desc", cod);
        Assert.Equal("", desc);
    }

    [Fact]
    public void GetCodeDescriptionSplitted_TrailingSpace_EmptyDescription()
    {
        var (cod, desc) = Functions.GetCodeDescriptionSplitted("CODE ");

        Assert.Equal("CODE", cod);
        Assert.Equal("", desc);
    }

    [Fact]
    public void GetCodeDescriptionSplitted_HyphenNoSpace_KeptTogether()
    {
        var (cod, desc) = Functions.GetCodeDescriptionSplitted("CODE-desc");

        Assert.Equal("CODE-desc", cod);
        Assert.Equal("", desc);
    }
}
