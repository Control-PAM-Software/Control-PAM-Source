using Control.Models.Entities;
using Control.Models.Responses;

namespace Control.Tests.Comparison;

public class ComparisonResultTests
{
    private static ItemAnexo Item(string code, string serial, decimal qty, string dueDate = "01/01/2030")
        => new ItemAnexo(code, "Desc", serial, qty, dueDate);

    [Fact]
    public void CompareItems_ExactMatch_GoesToCorrectItems()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 1) };
        var received = new List<ItemAnexo> { Item("A100", "SN1", 1) };

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Single(result.CorrectItems);
        Assert.Empty(result.MismatchedItems);
        Assert.Empty(result.MissingItems);
        Assert.Empty(result.ExtraItems);
    }

    [Fact]
    public void CompareItems_SerialMatchDifferentQuantity_GoesToMismatched()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 5) };
        var received = new List<ItemAnexo> { Item("A100", "SN1", 2) };

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Empty(result.CorrectItems);
        Assert.Single(result.MismatchedItems);
        Assert.True(result.MismatchedItems[0].QuantityDiffers);
        Assert.False(result.MismatchedItems[0].SerialNumberDiffers);
        Assert.Empty(result.MissingItems);
        Assert.Empty(result.ExtraItems);
    }

    [Fact]
    public void CompareItems_SerialMatchDifferentDueDate_GoesToMismatched()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 1, "01/01/2030") };
        var received = new List<ItemAnexo> { Item("A100", "SN1", 1, "01/01/2032") };

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Single(result.MismatchedItems);
        Assert.True(result.MismatchedItems[0].DueDateDiffers);
    }

    [Fact]
    public void CompareItems_MissingCode_GoesToMissing()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 1) };
        var received = new List<ItemAnexo>();

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Empty(result.CorrectItems);
        Assert.Single(result.MissingItems);
        Assert.Equal("A100", result.MissingItems[0].CodItem);
    }

    [Fact]
    public void CompareItems_UnexpectedCode_GoesToExtra()
    {
        var expected = new List<ItemAnexo>();
        var received = new List<ItemAnexo> { Item("Z999", "SN9", 1) };

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Single(result.ExtraItems);
        Assert.Equal("Z999", result.ExtraItems[0].CodItem);
    }

    [Fact]
    public void CompareItems_EmptyLists_ReturnsEmptyResult()
    {
        var result = ComparisonResult.CompareItems(new List<ItemAnexo>(), new List<ItemAnexo>());

        Assert.Empty(result.CorrectItems);
        Assert.Empty(result.MismatchedItems);
        Assert.Empty(result.MissingItems);
        Assert.Empty(result.ExtraItems);
    }

    [Fact]
    public void CompareItems_MixedScenario_ClassifiesEachBucket()
    {
        var expected = new List<ItemAnexo>
        {
            Item("A1", "SN1", 1),   // exact match
            Item("A2", "SN2", 3),   // missing
            Item("A3", "SN3", 1, "01/01/2030"), // mismatched (date)
        };
        var received = new List<ItemAnexo>
        {
            Item("A1", "SN1", 1),
            Item("A3", "SN3", 1, "01/01/2031"),
            Item("A4", "SN4", 2),   // extra
        };

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Single(result.CorrectItems);
        Assert.Single(result.MismatchedItems);
        Assert.Single(result.MissingItems);
        Assert.Single(result.ExtraItems);
    }

    [Fact]
    public void IsComparisonCorrect_TrueOnlyWhenAllMatch()
    {
        var exact = ComparisonResult.CompareItems(
            new List<ItemAnexo> { Item("A1", "SN1", 1) },
            new List<ItemAnexo> { Item("A1", "SN1", 1) });
        Assert.True(exact.IsComparisonCorrect());

        var withMissing = ComparisonResult.CompareItems(
            new List<ItemAnexo> { Item("A1", "SN1", 1) },
            new List<ItemAnexo>());
        Assert.False(withMissing.IsComparisonCorrect());

        var withMismatch = ComparisonResult.CompareItems(
            new List<ItemAnexo> { Item("A1", "SN1", 2) },
            new List<ItemAnexo> { Item("A1", "SN1", 1) });
        Assert.False(withMismatch.IsComparisonCorrect());

        var empty = ComparisonResult.CompareItems(new List<ItemAnexo>(), new List<ItemAnexo>());
        Assert.False(empty.IsComparisonCorrect());
    }

    [Fact]
    public void CompareItems_CodeGroupingIsCaseSensitive()
    {
        // El filtrado por código en CompareItems usa '==' (case-sensitive),
        // por lo que "abc1" no matchea el grupo "ABC1" y termina como faltante.
        var expected = new List<ItemAnexo> { Item("ABC1", "SN1", 1) };
        var received = new List<ItemAnexo> { Item("abc1", "sn1", 1) };

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Empty(result.CorrectItems);
        Assert.Single(result.MissingItems);
    }

    [Fact]
    public void CompareItems_GreedyMatching_PrefersLowestDifference()
    {
        var expected = new List<ItemAnexo> { Item("A1", "SN1", 1), Item("A1", "SN2", 1) };
        var received = new List<ItemAnexo> { Item("A1", "SN2", 1), Item("A1", "SN9", 1) };

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Single(result.CorrectItems);
        Assert.Single(result.MismatchedItems);
        Assert.Empty(result.ExtraItems);
        Assert.Empty(result.MissingItems);
    }
}
