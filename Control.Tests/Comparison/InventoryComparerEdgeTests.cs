using Control.Models.Entities;
using Control.Models.Responses;

namespace Control.Tests.Comparison;

public class InventoryComparerEdgeTests
{
    private static ItemAnexo Item(string code, string serial, decimal qty, string dueDate = "01/01/2030")
        => new ItemAnexo(code, "Desc", serial, qty, dueDate);

    [Fact]
    public void CompareLists_MultipleReceivedRows_ConsumedAcrossRows()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 5) };
        var received = new List<ItemAnexo> { Item("A100", "SN1", 3), Item("A100", "SN1", 2) };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Equal(2, result.CorrectItems.Count);
        Assert.Equal(3, result.CorrectItems[0].Quantity);
        Assert.Equal(2, result.CorrectItems[1].Quantity);
        Assert.Empty(result.MissingItems);
        Assert.Empty(result.ExtraItems);
    }

    [Fact]
    public void CompareLists_MultipleExpectedRows_ConsumedFromSingleReceived()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 3), Item("A100", "SN1", 3) };
        var received = new List<ItemAnexo> { Item("A100", "SN1", 4) };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Equal(2, result.CorrectItems.Count);
        Assert.Equal(3, result.CorrectItems[0].Quantity);
        Assert.Equal(1, result.CorrectItems[1].Quantity);
        Assert.Single(result.MissingItems);
        Assert.Equal(2, result.MissingItems[0].Quantity);
        Assert.Empty(result.ExtraItems);
    }

    [Fact]
    public void CompareLists_ExpectedSingleRow_DifferentSerials_SpreadAcrossReceived()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SNX", 5) };
        var received = new List<ItemAnexo> { Item("A100", "SNY", 2), Item("A100", "SNZ", 3) };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Empty(result.CorrectItems);
        Assert.Equal(2, result.MismatchedItems.Count);
        Assert.Equal(2, result.MismatchedItems[0].Received.Quantity);
        Assert.Equal(3, result.MismatchedItems[1].Received.Quantity);
        Assert.Empty(result.MissingItems);
        Assert.Empty(result.ExtraItems);
    }

    [Fact]
    public void CompareLists_ExactThenMismatch_LeftoverBecomesExtra()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SNX", 5), Item("A100", "SNY", 5) };
        var received = new List<ItemAnexo>
        {
            Item("A100", "SNX", 2),
            Item("A100", "SNY", 2),
            Item("A100", "SNZ", 6),
        };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Equal(2, result.CorrectItems.Count);
        Assert.Equal(4, result.CorrectItems.Sum(i => i.Quantity));
        Assert.Equal(2, result.MismatchedItems.Count);
        Assert.Equal(3, result.MismatchedItems[0].Received.Quantity);
        Assert.Equal(3, result.MismatchedItems[1].Received.Quantity);
        Assert.Empty(result.MissingItems);
        Assert.Empty(result.ExtraItems);
    }

    [Fact]
    public void CompareLists_ZeroQuantityExpected_IsDroppedSilently()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 0) };
        var received = new List<ItemAnexo> { Item("A100", "SN1", 0) };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Empty(result.CorrectItems);
        Assert.Empty(result.MismatchedItems);
        Assert.Empty(result.MissingItems);
        Assert.Empty(result.ExtraItems);
    }

    [Fact]
    public void CompareLists_NegativeQuantity_IsDroppedSilently()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", -2) };
        var received = new List<ItemAnexo> { Item("A100", "SN1", -2) };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Empty(result.CorrectItems);
        Assert.Empty(result.MissingItems);
    }

    [Fact]
    public void CompareLists_FractionalQuantity_Supported()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 1.5m) };
        var received = new List<ItemAnexo> { Item("A100", "SN1", 1.5m) };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Single(result.CorrectItems);
        Assert.Equal(1.5m, result.CorrectItems[0].Quantity);
    }

    [Fact]
    public void CompareLists_SerialWhitespace_IsMismatchNotExact()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 1) };
        var received = new List<ItemAnexo> { Item("A100", "SN1 ", 1) };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Empty(result.CorrectItems);
        Assert.Single(result.MismatchedItems);
        Assert.True(result.MismatchedItems[0].SerialNumberDiffers);
    }

    [Fact]
    public void CompareLists_NullCode_TreatedAsEmpty()
    {
        var expected = new List<ItemAnexo> { Item(null!, "SN1", 1) };
        var received = new List<ItemAnexo> { Item(null!, "SN1", 1) };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Single(result.CorrectItems);
    }

    [Fact]
    public void CompareLists_NullSerial_MatchesEmptySerial()
    {
        var expected = new List<ItemAnexo> { new ItemAnexo("A100", "D", null!, 1) };
        var received = new List<ItemAnexo> { new ItemAnexo("A100", "D", "", 1) };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Single(result.CorrectItems);
    }

    [Fact]
    public void CompareLists_DueDateFormatVariation_IsExactMatch()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 1, "1/1/2030") };
        var received = new List<ItemAnexo> { Item("A100", "SN1", 1, "01/01/2030") };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Single(result.CorrectItems);
    }

    [Fact]
    public void CompareLists_BlankVsWhitespaceDueDate_IsExactMatch()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 1, "") };
        var received = new List<ItemAnexo> { Item("A100", "SN1", 1, "   ") };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Single(result.CorrectItems);
    }

    [Fact]
    public void CompareLists_OneBlankOneFilledDueDate_IsMismatch()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 1, "") };
        var received = new List<ItemAnexo> { Item("A100", "SN1", 1, "01/01/2030") };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Empty(result.CorrectItems);
        Assert.Single(result.MismatchedItems);
        Assert.True(result.MismatchedItems[0].DueDateDiffers);
    }

    [Fact]
    public void CompareLists_ResultIsOrderIndependent()
    {
        var expected = new List<ItemAnexo> { Item("A", "S1", 2), Item("B", "S2", 1), Item("A", "S3", 3) };
        var received = new List<ItemAnexo> { Item("B", "S2", 1), Item("A", "S1", 2), Item("A", "S9", 1) };

        var resultForward = InventoryComparer.CompareLists(expected, received);
        var resultReverse = InventoryComparer.CompareLists(
            expected.AsEnumerable().Reverse().ToList(),
            received.AsEnumerable().Reverse().ToList());

        Assert.Equal(resultForward.CorrectItems.Sum(i => i.Quantity), resultReverse.CorrectItems.Sum(i => i.Quantity));
        Assert.Equal(resultForward.MismatchedItems.Count, resultReverse.MismatchedItems.Count);
        Assert.Equal(resultForward.MissingItems.Sum(i => i.Quantity), resultReverse.MissingItems.Sum(i => i.Quantity));
        Assert.Equal(resultForward.ExtraItems.Sum(i => i.Quantity), resultReverse.ExtraItems.Sum(i => i.Quantity));
    }

    [Fact]
    public void CompareLists_DoesNotMutateInputLists()
    {
        var expected = new List<ItemAnexo> { Item("A", "S1", 2) };
        var received = new List<ItemAnexo> { Item("A", "S2", 1) };

        var expectedSnapshot = expected.Select(i => (i.CodItem, i.SerialNumber, i.Quantity)).ToList();
        var receivedSnapshot = received.Select(i => (i.CodItem, i.SerialNumber, i.Quantity)).ToList();

        InventoryComparer.CompareLists(expected, received);

        Assert.Equal(expectedSnapshot, expected.Select(i => (i.CodItem, i.SerialNumber, i.Quantity)).ToList());
        Assert.Equal(receivedSnapshot, received.Select(i => (i.CodItem, i.SerialNumber, i.Quantity)).ToList());
    }

    [Fact]
    public void CompareLists_FullMixedScenario()
    {
        var expected = new List<ItemAnexo>
        {
            Item("A", "S1", 3),                      // exact (2) + missing (1)
            Item("B", "S2", 2, "01/01/2030"),        // mismatched (due date)
            Item("C", "S3", 4),                      // missing
            Item("D", "S4", 1),                      // exact
        };
        var received = new List<ItemAnexo>
        {
            Item("A", "S1", 2),
            Item("B", "S2", 2, "01/01/2031"),
            Item("D", "S4", 1),
            Item("E", "S9", 7),                      // extra
        };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Equal(3, result.CorrectItems.Sum(i => i.Quantity)); // A:2 + D:1
        Assert.Single(result.MismatchedItems);
        Assert.True(result.MismatchedItems[0].DueDateDiffers);
        Assert.Equal(5, result.MissingItems.Sum(i => i.Quantity)); // A:1 + C:4
        Assert.Single(result.ExtraItems);
        Assert.Equal(7, result.ExtraItems[0].Quantity);
        Assert.False(result.IsComparisonCorrect());
    }
}
