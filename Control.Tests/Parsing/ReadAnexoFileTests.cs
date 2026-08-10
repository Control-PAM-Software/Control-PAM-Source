using ClosedXML.Excel;
using Control.Logic;
using Control.Models.Entities;

namespace Control.Tests.Parsing;

public class ReadAnexoFileTests : IDisposable
{
    private readonly List<string> _tempFiles = new();

    private string CreateXlsx(params string[][] rows)
    {
        string path = Path.Combine(Path.GetTempPath(), $"anexo_{Guid.NewGuid():N}.xlsx");
        _tempFiles.Add(path);

        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Anexo");
        for (int r = 0; r < rows.Length; r++)
            for (int c = 0; c < rows[r].Length; c++)
                ws.Cell(r + 1, c + 1).Value = rows[r][c];
        wb.SaveAs(path);
        return path;
    }

    private string CreateHtml(string content)
    {
        string path = Path.Combine(Path.GetTempPath(), $"anexo_{Guid.NewGuid():N}.xls");
        _tempFiles.Add(path);
        File.WriteAllText(path, content);
        return path;
    }

    public void Dispose()
    {
        foreach (var f in _tempFiles)
            if (File.Exists(f))
                File.Delete(f);
    }

    [Fact]
    public void ReadAnexoFile_ParsesXlsx()
    {
        var path = CreateXlsx(
            new[] { "ArtCode", "Quantity", "Description", "SerialNr", "DueDate" },
            new[] { "A1", "5", "Desc1", "SN1", "01/01/2030" },
            new[] { "A2", "2", "Desc2", "SN2", "No Aplica" });

        var items = Functions.ReadAnexoFile(path, new Headers());

        Assert.NotNull(items);
        Assert.Equal(2, items.Count);
        Assert.Equal("A1", items[0].CodItem);
        Assert.Equal(5, items[0].Quantity);
        Assert.Equal("SN1", items[0].SerialNumber);
        Assert.Equal("01/01/2030", items[0].DueDate);
        Assert.Equal("A2", items[1].CodItem);
        Assert.Equal("", items[1].DueDate);
    }

    [Fact]
    public void ReadAnexoFile_ParsesMovementsBernafon()
    {
        var path = CreateXlsx(
            new[] { "ArtCode", "Quantity" },
            new[] { "B1", "3" },
            new[] { "B1", "2" },
            new[] { "B2", "4" });

        var items = Functions.ReadAnexoFile(path, new Headers(), movementsBernafon: true);

        Assert.NotNull(items);
        Assert.Equal(2, items.Count);
        Assert.Equal("B1", items[0].CodItem);
        Assert.Equal(5, items[0].Quantity);
        Assert.Equal("B2", items[1].CodItem);
        Assert.Equal(4, items[1].Quantity);
    }

    [Fact]
    public void ReadAnexoFile_ParsesHtmlFile()
    {
        var path = CreateHtml(
            "<!DOCTYPE html><html><body><table>" +
            "<thead><tr><th>ArtCode</th><th>Quantity</th><th>Description</th><th>SerialNr</th><th>DueDate</th></tr></thead>" +
            "<tbody>" +
            "<tr><td>A1</td><td>5</td><td>D1</td><td>SN1</td><td>01/01/2030</td></tr>" +
            "<tr><td>A2</td><td>2</td><td>D2</td><td>SN2</td><td>No Aplica</td></tr>" +
            "</tbody></table></body></html>");

        var items = Functions.ReadAnexoFile(path, new Headers());

        Assert.NotNull(items);
        Assert.Equal(2, items.Count);
        Assert.Equal("A1", items[0].CodItem);
        Assert.Equal(5, items[0].Quantity);
        Assert.Equal("01/01/2030", items[0].DueDate);
        // En la ruta HTML el vencimiento "No Aplica" se conserva tal cual
        Assert.Equal("No Aplica", items[1].DueDate);
    }

    [Fact]
    public void ReadAnexoFile_HtmlSerialWithDespacho_SplitsSerial()
    {
        var path = CreateHtml(
            "<html><body><table>" +
            "<thead><tr><th>ArtCode</th><th>Quantity</th><th>Description</th><th>SerialNr</th><th>DueDate</th></tr></thead>" +
            "<tbody><tr><td>A1</td><td>1</td><td>D1</td><td>SN1/9</td><td>01/01/2030</td></tr></tbody>" +
            "</table></body></html>");

        var items = Functions.ReadAnexoFile(path, new Headers());

        Assert.NotNull(items);
        Assert.Single(items);
        Assert.Equal("SN1", items[0].SerialNumber);
    }

    [Fact]
    public void ReadAnexoFile_XlsxGroupsRepeatedRows()
    {
        var path = CreateXlsx(
            new[] { "ArtCode", "Quantity", "Description", "SerialNr", "DueDate" },
            new[] { "A1", "2", "D1", "SN1", "01/01/2030" },
            new[] { "A1", "3", "D1", "SN1", "01/01/2030" });

        var items = Functions.ReadAnexoFile(path, new Headers());

        Assert.NotNull(items);
        Assert.Single(items);
        Assert.Equal(5, items[0].Quantity);
    }

    [Fact]
    public void ReadAnexoFile_GroupItemsFalse_KeepsSeparateRows()
    {
        var path = CreateXlsx(
            new[] { "ArtCode", "Quantity", "Description", "SerialNr", "DueDate" },
            new[] { "A1", "2", "D1", "SN1", "01/01/2030" },
            new[] { "A1", "3", "D1", "SN1", "01/01/2030" });

        var items = Functions.ReadAnexoFile(path, new Headers(), groupItems: false);

        Assert.NotNull(items);
        Assert.Equal(2, items.Count);
    }
}
