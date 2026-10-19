using System.Xml.Serialization;
using Control.Models.Settings;

namespace Control.Tests.Settings;

public class ConsignacionSettingsTests
{
    [Fact]
    public void Defaults_AreSetAccordingToSpec()
    {
        var s = new ConsignacionSettings();

        Assert.Equal("Artículo", s.MovColCode);
        Assert.Equal("Nro. Serie", s.MovColSerial);
        Assert.Equal("Fecha", s.MovColDate);
        Assert.Equal("Desde Depósito", s.MovColFrom);
        Assert.Equal("Hasta Depósito", s.MovColTo);

        Assert.Equal("Artículo", s.StockColCode);
        Assert.Equal("Nro. Serie", s.StockColSerial);
        Assert.Equal("Depósito de Stock", s.StockColDepot);
        Assert.Equal("Stock", s.StockColQty);

        Assert.Equal(30, s.PlazoLimite);
    }

    [Fact]
    public void SettingsModel_ExposesConsignacionReporte()
    {
        var model = new SettingsModel();

        Assert.NotNull(model.ConsignacionReporte);
        Assert.NotNull(model.ConsignacionReporte?.MovColSerial);
    }

    [Fact]
    public void RoundTrip_SerializationPreservesValues()
    {
        var model = new SettingsModel();

        model.ConsignacionReporte.MovColCode = "Código Art";
        model.ConsignacionReporte.MovColSerial = "Serie N°";
        model.ConsignacionReporte.MovColDate = "Fecha Mov";
        model.ConsignacionReporte.MovColFrom = "Origen";
        model.ConsignacionReporte.MovColTo = "Destino";
        model.ConsignacionReporte.StockColCode = "Código";
        model.ConsignacionReporte.StockColSerial = "N° Serie";
        model.ConsignacionReporte.StockColDepot = "Depósito";
        model.ConsignacionReporte.StockColQty = "Stock Act";
        model.ConsignacionReporte.PlazoLimite = 45;

        var xml = Serialize(model);
        var back = Deserialize(xml);

        var s = back.ConsignacionReporte;
        Assert.Equal("Código Art", s.MovColCode);
        Assert.Equal("Serie N°", s.MovColSerial);
        Assert.Equal("Fecha Mov", s.MovColDate);
        Assert.Equal("Origen", s.MovColFrom);
        Assert.Equal("Destino", s.MovColTo);
        Assert.Equal("Código", s.StockColCode);
        Assert.Equal("N° Serie", s.StockColSerial);
        Assert.Equal("Depósito", s.StockColDepot);
        Assert.Equal("Stock Act", s.StockColQty);
        Assert.Equal(45, s.PlazoLimite);
    }

    [Fact]
    public void OldXml_WithoutConsignacionNode_KeepsDefaults()
    {
        const string oldXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<SettingsModel xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <ColorDifferences>#ABCDEF</ColorDifferences>
</SettingsModel>";

        var model = Deserialize(oldXml);

        Assert.Equal("#ABCDEF", model.ColorDifferences);
        Assert.NotNull(model.ConsignacionReporte);
        Assert.Equal(30, model.ConsignacionReporte.PlazoLimite);
        Assert.Equal("Artículo", model.ConsignacionReporte.MovColCode);
        Assert.Equal("Depósito de Stock", model.ConsignacionReporte.StockColDepot);
    }

    private static string Serialize(SettingsModel model)
    {
        var serializer = new XmlSerializer(typeof(SettingsModel));
        using var sw = new StringWriter();
        serializer.Serialize(sw, model);
        return sw.ToString();
    }

    private static SettingsModel Deserialize(string xml)
    {
        var serializer = new XmlSerializer(typeof(SettingsModel));
        using var reader = new StringReader(xml);
        return (SettingsModel)serializer.Deserialize(reader)!;
    }
}