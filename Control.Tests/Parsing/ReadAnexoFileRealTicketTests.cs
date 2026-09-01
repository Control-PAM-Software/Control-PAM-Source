using Control.Logic;
using Control.Models.Entities;
using Control.Models.Settings;

namespace Control.Tests.Parsing;

public class ReadAnexoFileRealTicketTests
{
    private static Headers BuildValijasABHeaders()
    {
        var header = new Headers();
        header.ArtCode.Name = "Código";
        header.Qty.Name = "Unidades";
        header.Description.Name = "Descripción";
        header.SerialNr.Name = "Nº de SERIE";
        header.DueDate.Name = "Vencimiento";
        return header;
    }

    [Fact]
    public void ReadAnexoFile_RealTicketHtml_GroupsByCodeSerialDueDate()
    {
        string path = Path.GetFullPath(Path.Combine(
            AppContext.BaseDirectory, "..", "..", "..", "..",
            "Tickets", "Agrupar_Items", "Anexo_AB_Prueba.xls"));

        Assert.True(File.Exists(path), $"Archivo de prueba no encontrado: {path}");

        var items = Functions.ReadAnexoFile(path, BuildValijasABHeaders());

        Assert.NotNull(items);
        // AB-1001/SN001/31-08-2030 (2+3) -> 5
        // AB-1001/SN001/30-11-2029        -> 1 (distinto vencimiento)
        // AB-1002/SN002/31-12-2030 (2+1)  -> 3
        Assert.Equal(3, items.Count);

        var a = items.First(x => x.CodItem == "AB-1001" && x.DueDate == "31/08/2030");
        Assert.Equal(5, a.Quantity);
        var b = items.First(x => x.CodItem == "AB-1001" && x.DueDate == "30/11/2029");
        Assert.Equal(1, b.Quantity);
        var c = items.First(x => x.CodItem == "AB-1002");
        Assert.Equal(3, c.Quantity);
    }
}
