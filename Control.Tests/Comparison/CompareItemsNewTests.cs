using Control.Models.Entities;
using Control.Models.Responses;

namespace Control.Tests.Comparison;

public class CompareItemsNewTests
{
    private static ItemAnexo Item(string code, string serial, decimal qty, string dueDate = "01/01/2030")
        => new ItemAnexo(code, "Desc", serial, qty, dueDate);

    [Fact]
    public void CompareItemsNew_ExactMatch_RemovedFromBothLists()
    {
        var items = new List<ItemAnexo> { Item("A", "SN1", 1) };
        var received = new List<ItemAnexo> { Item("A", "SN1", 1) };

        var result = ComparisonResult.CompareItemsNew(items, received);

        Assert.Empty(result.MismatchedItems);
        Assert.Empty(items);
        Assert.Empty(received);
    }

    [Fact]
    public void CompareItemsNew_ExpectedMoreThanReceived_ReducesExpectedAndRemovesReceived()
    {
        var items = new List<ItemAnexo> { Item("A", "SN1", 5) };
        var received = new List<ItemAnexo> { Item("A", "SN1", 2) };

        var result = ComparisonResult.CompareItemsNew(items, received);

        Assert.Single(result.MismatchedItems);
        Assert.True(result.MismatchedItems[0].QuantityDiffers);

        Assert.Single(items);
        Assert.Equal(3, items[0].Quantity);
        Assert.Empty(received);
    }

    [Fact]
    public void CompareItemsNew_ReceivedMoreThanExpected_ReducesReceivedAndRemovesExpected()
    {
        var items = new List<ItemAnexo> { Item("A", "SN1", 2) };
        var received = new List<ItemAnexo> { Item("A", "SN1", 5) };

        var result = ComparisonResult.CompareItemsNew(items, received);

        Assert.Single(result.MismatchedItems);
        Assert.Empty(items);
        Assert.Single(received);
        Assert.Equal(3, received[0].Quantity);
    }

    [Fact]
    public void CompareItemsNew_EqualQuantitySameSerial_IsExactMatch_RemovedFromBothLists()
    {
        var items = new List<ItemAnexo> { Item("A", "SN1", 2, "01/01/2030") };
        var received = new List<ItemAnexo> { Item("A", "SN1", 2, "01/01/2030") };

        var result = ComparisonResult.CompareItemsNew(items, received);

        Assert.Empty(result.MismatchedItems);
        Assert.Empty(items);
        Assert.Empty(received);
    }

    [Fact]
    public void CompareItemsNew_PartialMatch_LeavesUnmatchedExpected()
    {
        var items = new List<ItemAnexo> { Item("A", "SN1", 5), Item("B", "SN2", 1) };
        var received = new List<ItemAnexo> { Item("A", "SN1", 5) };

        var result = ComparisonResult.CompareItemsNew(items, received);

        Assert.Empty(result.MismatchedItems);
        Assert.Single(items);
        Assert.Equal("B", items[0].CodItem);
        Assert.Empty(received);
    }

    [Fact]
    public void CompareItemsNew_NoMatch_LeavesListsUntouched()
    {
        var items = new List<ItemAnexo> { Item("A", "SN1", 1) };
        var received = new List<ItemAnexo> { Item("B", "SN2", 1) };

        var result = ComparisonResult.CompareItemsNew(items, received);

        Assert.Empty(result.MismatchedItems);
        Assert.Single(items);
        Assert.Single(received);
    }

    [Fact]
    public void CompareItemsNew_TwoReceivedRowsAgainstOneExpected()
    {
        var items = new List<ItemAnexo> { Item("A", "SN1", 3) };
        var received = new List<ItemAnexo> { Item("A", "SN1", 1), Item("A", "SN1", 1) };

        var result = ComparisonResult.CompareItemsNew(items, received);

        Assert.Equal(2, result.MismatchedItems.Count);
        Assert.Single(items);
        Assert.Equal(1, items[0].Quantity);
        Assert.Empty(received);
    }

    [Fact]
    public void CompareItemsNew_DifferentDueDate_NotRemovedAsExact()
    {
        var items = new List<ItemAnexo> { Item("A", "SN1", 1, "01/01/2030") };
        var received = new List<ItemAnexo> { Item("A", "SN1", 1, "01/01/2031") };

        var result = ComparisonResult.CompareItemsNew(items, received);

        // misma serie/cantidad pero distinto vencimiento -> no es exacto, tampoco difiere solo qty
        Assert.Empty(result.MismatchedItems);
        Assert.Single(items);
        Assert.Single(received);
    }

    [Fact]
    public void CompareItemsNew_CaseInsensitiveSerialMatching()
    {
        var items = new List<ItemAnexo> { Item("A", "SN1", 3) };
        var received = new List<ItemAnexo> { Item("A", "sn1", 2) };

        var result = ComparisonResult.CompareItemsNew(items, received);

        Assert.Single(result.MismatchedItems);
        Assert.Empty(received);
        Assert.Single(items);
        Assert.Equal(1, items[0].Quantity);
    }

    [Fact]
    public void RemoveExactItems_WithMultipleSameSerialRows_RemovesFirstByCodeSerial()
    {
        // dos recibidos con misma serie/cantidad, uno matchea exacto con el esperado.
        // el segundo lookup por codigo+serie (case-sensitive) remueve la primera coincidencia
        var items = new List<ItemAnexo> { Item("A", "SN1", 1) };
        var received = new List<ItemAnexo> { Item("A", "SN1", 1), Item("A", "SN1", 2) };

        var result = ComparisonResult.CompareItemsNew(items, received);

        Assert.Empty(items);
        Assert.Single(received);
        Assert.Equal(2, received[0].Quantity);
    }
}
