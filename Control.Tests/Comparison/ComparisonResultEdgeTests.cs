using Control.Models.Entities;
using Control.Models.Responses;

namespace Control.Tests.Comparison;

public class ComparisonResultEdgeTests
{
    private static ItemAnexo Item(string code, string serial, decimal qty, string dueDate = "01/01/2030")
        => new ItemAnexo(code, "Desc", serial, qty, dueDate);

    [Fact]
    public void CompareItems_SingleExpectedRow_SplitAcrossTwoReceived()
    {
        // qty 2 esperado, recibido en dos filas de 1 -> la primera matchea por serial (mismatch),
        // la segunda queda como extra
        var expected = new List<ItemAnexo> { Item("A", "SN1", 2) };
        var received = new List<ItemAnexo> { Item("A", "SN1", 1), Item("A", "SN1", 1) };

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Empty(result.CorrectItems);
        Assert.Single(result.MismatchedItems);
        Assert.Single(result.ExtraItems);
        Assert.Empty(result.MissingItems);
    }

    [Fact]
    public void CompareItems_DuplicateExactRows_AllMatched()
    {
        var expected = new List<ItemAnexo> { Item("A", "SN1", 2), Item("A", "SN1", 2) };
        var received = new List<ItemAnexo> { Item("A", "SN1", 2), Item("A", "SN1", 2) };

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Equal(2, result.CorrectItems.Count);
        Assert.Empty(result.MismatchedItems);
        Assert.Empty(result.ExtraItems);
        Assert.Empty(result.MissingItems);
    }

    [Fact]
    public void CompareItems_MixedExactAndMismatch_SameSerial()
    {
        var expected = new List<ItemAnexo> { Item("A", "SN1", 2), Item("A", "SN1", 1) };
        var received = new List<ItemAnexo> { Item("A", "SN1", 1), Item("A", "SN1", 1) };

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Single(result.CorrectItems);   // la fila de qty 1
        Assert.Single(result.MismatchedItems); // la fila de qty 2 contra el otro 1
        Assert.Empty(result.ExtraItems);
        Assert.Empty(result.MissingItems);
    }

    [Fact]
    public void CompareItems_BlankSerial_MatchesBySerial()
    {
        var expected = new List<ItemAnexo> { Item("A", "", 1) };
        var received = new List<ItemAnexo> { Item("A", "", 1) };

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Single(result.CorrectItems);
    }

    [Fact]
    public void CompareItems_BlankSerialDifferentQuantity_GoesToMismatch()
    {
        var expected = new List<ItemAnexo> { Item("A", "", 5) };
        var received = new List<ItemAnexo> { Item("A", "", 2) };

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Empty(result.CorrectItems);
        Assert.Single(result.MismatchedItems);
        Assert.True(result.MismatchedItems[0].QuantityDiffers);
    }

    [Fact]
    public void CompareItems_ExtraReceivedWithSameCodeAndDifferentSerial()
    {
        var expected = new List<ItemAnexo> { Item("A", "SN1", 1) };
        var received = new List<ItemAnexo> { Item("A", "SN1", 1), Item("A", "SN2", 1) };

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Single(result.CorrectItems);
        Assert.Empty(result.MismatchedItems);
        Assert.Single(result.ExtraItems);
        Assert.Equal("SN2", result.ExtraItems[0].SerialNumber);
    }

    [Fact]
    public void CompareItems_AllReceivedUnmatched_AllBecomeExtra()
    {
        var expected = new List<ItemAnexo>();
        var received = new List<ItemAnexo> { Item("A", "S1", 1), Item("B", "S2", 2), Item("A", "S3", 1) };

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Empty(result.CorrectItems);
        Assert.Equal(3, result.ExtraItems.Count);
    }

    [Fact]
    public void CompareItems_NullCodItem_Throws()
    {
        // GroupBy(x => x.CodItem) lanza ArgumentNullException con clave null
        var expected = new List<ItemAnexo> { new ItemAnexo(null!, "D", "SN1", 1) };
        var received = new List<ItemAnexo> { new ItemAnexo(null!, "D", "SN1", 1) };

        Assert.Throws<ArgumentNullException>(() => ComparisonResult.CompareItems(expected, received));
    }

    [Fact]
    public void CompareItems_DoesNotMutateInputLists()
    {
        var expected = new List<ItemAnexo> { Item("A", "S1", 2) };
        var received = new List<ItemAnexo> { Item("A", "S2", 1) };

        var expectedSnapshot = expected.Select(i => (i.CodItem, i.SerialNumber, i.Quantity)).ToList();
        var receivedSnapshot = received.Select(i => (i.CodItem, i.SerialNumber, i.Quantity)).ToList();

        ComparisonResult.CompareItems(expected, received);

        Assert.Equal(expectedSnapshot, expected.Select(i => (i.CodItem, i.SerialNumber, i.Quantity)).ToList());
        Assert.Equal(receivedSnapshot, received.Select(i => (i.CodItem, i.SerialNumber, i.Quantity)).ToList());
    }

    [Fact]
    public void CompareItems_DuplicateExpectedNotReceived_AllMissing()
    {
        var expected = new List<ItemAnexo> { Item("A", "SN1", 1), Item("A", "SN1", 1) };
        var received = new List<ItemAnexo>();

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Equal(2, result.MissingItems.Count);
    }

    [Fact]
    public void CompareItems_MatchPrefersSameSerialOverRandom()
    {
        // Aunque "SN9" exista recibido, el greedy debe casar SN1 con SN1 (costo 0) primero
        var expected = new List<ItemAnexo> { Item("A", "SN1", 1), Item("A", "SN2", 1) };
        var received = new List<ItemAnexo> { Item("A", "SN2", 1), Item("A", "SN9", 1) };

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Single(result.CorrectItems);
        Assert.Single(result.MismatchedItems);
        Assert.Equal("SN2", result.CorrectItems[0].SerialNumber);
    }

    [Fact]
    public void CompareItems_LargeList_PerformsGreedyWithoutError()
    {
        var expected = Enumerable.Range(1, 200).Select(i => Item($"C{i % 10}", $"SN{i}", 1)).ToList();
        var received = Enumerable.Range(1, 200).Select(i => Item($"C{i % 10}", $"SN{i + 500}", 1)).ToList();

        var result = ComparisonResult.CompareItems(expected, received);

        Assert.Equal(200, result.CorrectItems.Count + result.MismatchedItems.Count);
    }
}
