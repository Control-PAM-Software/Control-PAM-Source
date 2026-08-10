using Control.Models.Entities;
using Control.Models.Responses;

namespace Control.Tests.Comparison;

public class InventoryComparerTests
{
    private static ItemAnexo Item(string code, string serial, decimal qty, string dueDate = "01/01/2030")
        => new ItemAnexo(code, "Desc", serial, qty, dueDate);

    [Fact]
    public void CompareLists_ExactMatch_GoesToCorrectItems()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 3) };
        var received = new List<ItemAnexo> { Item("A100", "SN1", 3) };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Single(result.CorrectItems);
        Assert.Empty(result.MismatchedItems);
        Assert.Empty(result.MissingItems);
        Assert.Empty(result.ExtraItems);
        Assert.Equal(3, result.CorrectItems[0].Quantity);
    }

    [Fact]
    public void CompareLists_PartialQuantity_ReportsCorrectAndMissing()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 5) };
        var received = new List<ItemAnexo> { Item("A100", "SN1", 3) };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Single(result.CorrectItems);
        Assert.Equal(3, result.CorrectItems[0].Quantity);
        Assert.Single(result.MissingItems);
        Assert.Equal(2, result.MissingItems[0].Quantity);
        Assert.Empty(result.ExtraItems);
    }

    [Fact]
    public void CompareLists_SurplusQuantity_ReportsCorrectAndExtra()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 2) };
        var received = new List<ItemAnexo> { Item("A100", "SN1", 4) };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Single(result.CorrectItems);
        Assert.Equal(2, result.CorrectItems[0].Quantity);
        Assert.Single(result.ExtraItems);
        Assert.Equal(2, result.ExtraItems[0].Quantity);
        Assert.Empty(result.MissingItems);
    }

    [Fact]
    public void CompareLists_SameCodeDifferentSerial_GoesToMismatched()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 1) };
        var received = new List<ItemAnexo> { Item("A100", "SN2", 1) };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Empty(result.CorrectItems);
        Assert.Single(result.MismatchedItems);
        Assert.True(result.MismatchedItems[0].SerialNumberDiffers);
        Assert.False(result.MismatchedItems[0].DueDateDiffers);
        Assert.Empty(result.MissingItems);
        Assert.Empty(result.ExtraItems);
    }

    [Fact]
    public void CompareLists_SameCodeDifferentDueDate_GoesToMismatched()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 1, "01/01/2030") };
        var received = new List<ItemAnexo> { Item("A100", "SN1", 1, "01/01/2031") };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Single(result.MismatchedItems);
        Assert.True(result.MismatchedItems[0].DueDateDiffers);
        Assert.False(result.MismatchedItems[0].SerialNumberDiffers);
    }

    [Fact]
    public void CompareLists_ItemNotReceived_GoesToMissing()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 1) };
        var received = new List<ItemAnexo>();

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Empty(result.CorrectItems);
        Assert.Single(result.MissingItems);
        Assert.Equal("A100", result.MissingItems[0].CodItem);
        Assert.Empty(result.ExtraItems);
    }

    [Fact]
    public void CompareLists_UnexpectedItem_GoesToExtra()
    {
        var expected = new List<ItemAnexo>();
        var received = new List<ItemAnexo> { Item("Z999", "SN9", 1) };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Empty(result.CorrectItems);
        Assert.Empty(result.MissingItems);
        Assert.Single(result.ExtraItems);
        Assert.Equal("Z999", result.ExtraItems[0].CodItem);
    }

    [Fact]
    public void CompareLists_EmptyLists_ReturnsEmptyResult()
    {
        var result = InventoryComparer.CompareLists(new List<ItemAnexo>(), new List<ItemAnexo>());

        Assert.Empty(result.CorrectItems);
        Assert.Empty(result.MismatchedItems);
        Assert.Empty(result.MissingItems);
        Assert.Empty(result.ExtraItems);
    }

    [Fact]
    public void CompareLists_CodesAreCaseInsensitive()
    {
        var expected = new List<ItemAnexo> { Item("ABC100", "SN1", 1) };
        var received = new List<ItemAnexo> { Item("abc100", "SN1", 1) };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Single(result.CorrectItems);
    }

    [Fact]
    public void CompareLists_MultipleRows_ReconcilesByUnit()
    {
        var expected = new List<ItemAnexo> { Item("A100", "SN1", 3), Item("A100", "SN2", 4) };
        var received = new List<ItemAnexo>
        {
            Item("A100", "SN1", 1),
            Item("A100", "SN2", 4),
            Item("A100", "SN1", 2),
        };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Equal(3, result.CorrectItems.Count);
        Assert.Empty(result.MissingItems);
        Assert.Empty(result.ExtraItems);
    }

    [Fact]
    public void CompareLists_BlankSerialAndDate_MatchesWhenBothBlank()
    {
        var expected = new List<ItemAnexo> { Item("A100", "", 2, "") };
        var received = new List<ItemAnexo> { Item("A100", "", 2, "") };

        var result = InventoryComparer.CompareLists(expected, received);

        Assert.Single(result.CorrectItems);
        Assert.Equal(2, result.CorrectItems[0].Quantity);
    }
}
