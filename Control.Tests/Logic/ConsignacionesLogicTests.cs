using System;
using System.Linq;
using Control.Logic;
using Control.Models.Entities;
using Control.Models.Settings;

namespace Control.Tests.Logic;

public class ConsignacionesLogicTests
{
    private static string Sample(string name)
    {
        string path = System.IO.Path.Combine(AppContext.BaseDirectory, "Samples", name);
        Assert.True(System.IO.File.Exists(path), $"FaltÃ³ la muestra: {path}");
        return path;
    }

    [Fact]
    public void LeerMovimientos_OnHtmlSample_ReadsNestedDetails()
    {
        var movimientos = ConsignacionesLogic.LeerMovimientos(
            Sample("Movimientos_Stock.xls"), new ConsignacionSettings());

        Assert.NotNull(movimientos);
        Assert.NotEmpty(movimientos!);
    }

    [Fact]
    public void LeerMovimientos_OnHtmlSample_SplitsSerieAndDespacho()
    {
        var movimientos = ConsignacionesLogic.LeerMovimientos(
            Sample("Movimientos_Stock.xls"), new ConsignacionSettings());

        Assert.NotNull(movimientos);
        Assert.DoesNotContain(movimientos!, m => m.Serial.Contains("/"));
    }

    [Fact]
    public void LeerMovimientos_OnHtmlSample_MatchesExpectedCount()
    {
        var movimientos = ConsignacionesLogic.LeerMovimientos(
            Sample("Movimientos_Stock.xls"), new ConsignacionSettings());

        // 14 movimientos con tabla anidada, 17 lÃ­neas de detalle reales (tablas 7, 11 y 13 con 2 Ã­tems).
        Assert.Equal(17, movimientos!.Count);
    }

    [Fact]
    public void LeerMovimientos_OnHtmlSample_ParsesDatesAndDepots()
    {
        var movimientos = ConsignacionesLogic.LeerMovimientos(
            Sample("Movimientos_Stock.xls"), new ConsignacionSettings());

        Assert.NotNull(movimientos);

        var primero = movimientos![0];
        Assert.Equal("310078304", primero.Serial);
        Assert.Equal("CI-7132-003", primero.Code);
        Assert.Equal(new DateTime(2026, 6, 17), primero.Date);

        // Los depÃ³sitos llegan desde las columnas mapeadas de la fila de cabecera del movimiento.
        Assert.Equal("500", primero.FromDepto);
        Assert.Equal("401-RMA", primero.ToDepto);
    }

    [Fact]
    public void LeerMovimientos_OnHtmlSample_KeepsRepeatedSerials()
    {
        var movimientos = ConsignacionesLogic.LeerMovimientos(
            Sample("Movimientos_Stock.xls"), new ConsignacionSettings());

        Assert.NotNull(movimientos);

        // Una misma serie puede recibir mÃ¡s de un movimiento; el cÃ¡lculo decide quÃ© fecha usar.
        Assert.Equal(3, movimientos!.Count(m => m.Serial == "310194741"));
    }

    [Fact]
    public void LeerStock_OnHtmlSample_ReadsRows()
    {
        var stock = ConsignacionesLogic.LeerStock(
            Sample("Stock_Actual.xls"), new ConsignacionSettings());

        Assert.NotNull(stock);
        Assert.NotEmpty(stock!);
    }

    [Fact]
    public void LeerStock_OnHtmlSample_DiscardsSummaryRows()
    {
        var stock = ConsignacionesLogic.LeerStock(
            Sample("Stock_Actual.xls"), new ConsignacionSettings());

        Assert.NotNull(stock);
        // Resumen del export: "Filas 77" â†’ 77 filas de datos reales.
        Assert.Equal(77, stock!.Count);
    }

    [Fact]
    public void LeerStock_OnHtmlSample_ParsesSerieDeptoAndQty()
    {
        var stock = ConsignacionesLogic.LeerStock(
            Sample("Stock_Actual.xls"), new ConsignacionSettings());

        Assert.NotNull(stock);

        var item = stock!.FirstOrDefault(s => s.Serial == "J4071653");
        Assert.NotNull(item);
        Assert.Equal("173388", item!.Code);
        Assert.Equal("301", item.Depto);
        Assert.Equal(1, item.Qty);

        var multi = stock!.FirstOrDefault(s => s.Serial == "47709271");
        Assert.NotNull(multi);
        Assert.Equal("M52660", multi!.Code);
        Assert.Equal(1, multi.Qty);
    }

    [Fact]
    public void LeerMovimientos_OnProduccionXlsx_ParseaDetalleAnidado()
    {
        var movimientos = ConsignacionesLogic.LeerMovimientos(
            Sample("Movimientos_Produccion.xlsx"), new ConsignacionSettings());

        Assert.NotNull(movimientos);
        Assert.NotEmpty(movimientos!);

        // 26 movimientos, cada uno con su sub-cabecera de detalle; de todas las lineas de
        // detalle solo 405 tienen numero de serie (el resto son accesorios sin serializar).
        Assert.Equal(405, movimientos!.Count);
    }

    [Fact]
    public void LeerMovimientos_OnProduccionXlsx_SoloDevuelveItemsConSerie()
    {
        var movimientos = ConsignacionesLogic.LeerMovimientos(
            Sample("Movimientos_Produccion.xlsx"), new ConsignacionSettings());

        Assert.NotNull(movimientos);
        // Los accesorios sin serializar (auriculares, enchufes, herramientas) quedan fuera del reporte.
        Assert.DoesNotContain(movimientos!, m => string.IsNullOrWhiteSpace(m.Serial));
    }

    [Fact]
    public void LeerMovimientos_OnProduccionXlsx_HeredaFechaYDepositosDelMovimiento()
    {
        var movimientos = ConsignacionesLogic.LeerMovimientos(
            Sample("Movimientos_Produccion.xlsx"), new ConsignacionSettings());

        Assert.NotNull(movimientos);

        // El detalle hereda la fecha (serial de Excel 46085) y los depósitos de su fila de movimiento.
        var primero = movimientos![0];
        Assert.Equal("21BSMNW9", primero.Serial);
        Assert.Equal("240319", primero.Code);
        Assert.Equal(new DateTime(2026, 3, 4), primero.Date);
        Assert.Equal("200", primero.FromDepto);
        Assert.Equal("210", primero.ToDepto);

        // Un movimiento con destino distinto (200 → 202) se mantiene en su propio contexto.
        var aZizzias = movimientos.First(m => m.Serial == "2130856715");
        Assert.Equal(new DateTime(2026, 4, 24), aZizzias.Date);
        Assert.Equal("200", aZizzias.FromDepto);
        Assert.Equal("202", aZizzias.ToDepto);
    }

    [Fact]
    public void LeerMovimientos_OnProduccionXlsx_NoRepiteSeries()
    {
        var movimientos = ConsignacionesLogic.LeerMovimientos(
            Sample("Movimientos_Produccion.xlsx"), new ConsignacionSettings());

        Assert.NotNull(movimientos);

        // En el archivo de produccion cada serie aparece una sola vez: 405 lineas, 405 series.
        Assert.Equal(movimientos!.Count, movimientos.Select(m => m.Serial).Distinct().Count());
    }

    [Fact]
    public void LeerStock_OnProduccionXlsx_DiscardsSummaryRows()
    {
        var stock = ConsignacionesLogic.LeerStock(
            Sample("Stock_Produccion.xlsx"), new ConsignacionSettings());

        Assert.NotNull(stock);
        // El export cierra con "Filas 239" y "Artículos 58": 239 filas de datos reales.
        Assert.Equal(239, stock!.Count);
    }

    [Fact]
    public void LeerStock_OnProduccionXlsx_ParsesSerieDeptoAndQty()
    {
        var stock = ConsignacionesLogic.LeerStock(
            Sample("Stock_Produccion.xlsx"), new ConsignacionSettings());

        Assert.NotNull(stock);

        var item = stock!.First(s => s.Serial == "212311875695");
        Assert.Equal("200297", item.Code);
        Assert.Equal("210", item.Depto);
        Assert.Equal(1, item.Qty);
    }

    [Fact]
    public void ComputeEstados_EndToEnd_OnProduccionXlsx()
    {
        var settings = new ConsignacionSettings();

        var movimientos = ConsignacionesLogic.LeerMovimientos(Sample("Movimientos_Produccion.xlsx"), settings);
        var stock = ConsignacionesLogic.LeerStock(Sample("Stock_Produccion.xlsx"), settings);

        var items = ConsignacionesLogic.ComputeEstados(movimientos, stock, settings, new DateTime(2026, 9, 22));

        Assert.NotNull(items);
        Assert.NotEmpty(items!);

        // 202 series en stock (deposito 210) + series de movimientos que ya no están en stock.
        Assert.Equal(202, items!.Count(i => i.CurrentDepot != ""));
        Assert.All(items, i => Assert.False(string.IsNullOrWhiteSpace(i.Serial)));

        // Cada serie en stock queda EnPlazo o Vencida, y las entregadas no tienen depósito actual.
        Assert.Equal(202, items.Count(i => i.State == ConsignacionEstado.EnPlazo)
                       + items.Count(i => i.State == ConsignacionEstado.Vencida));
        Assert.All(items.Where(i => i.Delivered), i => Assert.Equal("", i.CurrentDepot));
    }

    [Fact]
    public void ComputeEstados_ReglaA_EnStockDentroDePlazoEsEnPlazo()
    {
        var mov = new List<MovimientoConsignacion>
        {
            new() { Serial = "S1001", Code = "CI-1", Date = Fecha(10) }
        };
        var stock = new List<StockConsignacion>
        {
            new() { Serial = "S1001", Code = "CI-1", Depto = "301", Qty = 1 }
        };

        var items = ConsignacionesLogic.ComputeEstados(mov, stock, Plazo30(), Hoy);

        var item = AssertSingle(items, "S1001");
        Assert.Equal(ConsignacionEstado.EnPlazo, item.State);
        Assert.Equal(10, item.DaysElapsed);
        Assert.Equal("301", item.CurrentDepot);
        Assert.False(item.Delivered);
        Assert.False(item.SerieSinMovimiento);
        Assert.Equal("CI-1", item.Code);
    }

    [Fact]
    public void ComputeEstados_ReglaB_EnStockFueraDePlazoEsVencida()
    {
        var mov = new List<MovimientoConsignacion>
        {
            new() { Serial = "S2002", Code = "CI-2", Date = Fecha(45) }
        };
        var stock = new List<StockConsignacion>
        {
            new() { Serial = "S2002", Code = "CI-2", Depto = "301", Qty = 1 }
        };

        var items = ConsignacionesLogic.ComputeEstados(mov, stock, Plazo30(), Hoy);

        var item = AssertSingle(items, "S2002");
        Assert.Equal(ConsignacionEstado.Vencida, item.State);
        Assert.Equal(45, item.DaysElapsed);
        Assert.False(item.SerieSinMovimiento);
    }

    [Fact]
    public void ComputeEstados_ReglaC_SerieSinStockEsEntregado()
    {
        var mov = new List<MovimientoConsignacion>
        {
            new() { Serial = "S3003", Code = "CI-3", Date = Fecha(80) }
        };

        var items = ConsignacionesLogic.ComputeEstados(mov, new List<StockConsignacion>(), Plazo30(), Hoy);

        var item = AssertSingle(items, "S3003");
        Assert.Equal(ConsignacionEstado.Entregado, item.State);
        Assert.True(item.Delivered);
        Assert.Equal(80, item.DaysElapsed);
        Assert.Equal("", item.CurrentDepot);
    }

    [Fact]
    public void ComputeEstados_ReglaD_EnStockSinMovimientoEsVencidaResaltada()
    {
        var stock = new List<StockConsignacion>
        {
            new() { Serial = "S4004", Code = "CI-4", Depto = "301", Qty = 1 }
        };

        var items = ConsignacionesLogic.ComputeEstados(new List<MovimientoConsignacion>(), stock, Plazo30(), Hoy);

        var item = AssertSingle(items, "S4004");
        Assert.Equal(ConsignacionEstado.Vencida, item.State);
        Assert.True(item.SerieSinMovimiento);
        Assert.Equal("", item.DepartureDate);
        Assert.Equal(0, item.DaysElapsed);
    }

    [Fact]
    public void ComputeEstados_Borde_DiasIgualesAlPlazoEsEnPlazo()
    {
        var mov = new List<MovimientoConsignacion>
        {
            new() { Serial = "S5005", Code = "CI-5", Date = Fecha(30) }
        };
        var stock = new List<StockConsignacion>
        {
            new() { Serial = "S5005", Code = "CI-5", Depto = "301", Qty = 1 }
        };

        var items = ConsignacionesLogic.ComputeEstados(mov, stock, Plazo30(), Hoy);

        Assert.Equal(ConsignacionEstado.EnPlazo, AssertSingle(items, "S5005").State);
    }

    [Fact]
    public void ComputeEstados_MovimientoMultiple_UsaElMasAntiguo()
    {
        var mov = new List<MovimientoConsignacion>
        {
            new() { Serial = "S6006", Code = "CI-6", Date = Fecha(50) },
            new() { Serial = "S6006", Code = "CI-6", Date = Fecha(5) }
        };
        var stock = new List<StockConsignacion>
        {
            new() { Serial = "S6006", Code = "CI-6", Depto = "301", Qty = 1 }
        };

        var items = ConsignacionesLogic.ComputeEstados(mov, stock, Plazo30(), Hoy);

        var item = AssertSingle(items, "S6006");
        Assert.Equal(50, item.DaysElapsed);
        Assert.Equal(Fecha(50).ToString("dd/MM/yyyy"), item.DepartureDate);
        Assert.Equal(ConsignacionEstado.Vencida, item.State);
    }

    [Fact]
    public void ComputeEstados_IgnoraStockSinSerial()
    {
        var stock = new List<StockConsignacion>
        {
            new() { Serial = "", Code = "CI-7", Depto = "301", Qty = 5 },
            new() { Serial = "0", Code = "CI-8", Depto = "301", Qty = 5 }
        };

        var items = ConsignacionesLogic.ComputeEstados(new List<MovimientoConsignacion>(), stock, Plazo30(), Hoy);

        Assert.NotNull(items);
        Assert.Empty(items!);
    }

    [Fact]
    public void ComputeEstados_EndToEnd_OnSamples()
    {
        var settings = new ConsignacionSettings();

        var movimientos = ConsignacionesLogic.LeerMovimientos(Sample("Movimientos_Stock.xls"), settings);
        var stock = ConsignacionesLogic.LeerStock(Sample("Stock_Actual.xls"), settings);

        var items = ConsignacionesLogic.ComputeEstados(movimientos, stock, settings, Hoy);

        Assert.NotNull(items);
        Assert.NotEmpty(items!);

        // 68 series reales en stock (sin movimientos correlativos) + 11 series de movimientos ya entregadas.
        Assert.Equal(79, items!.Count);
        Assert.Equal(11, items.Count(i => i.State == ConsignacionEstado.Entregado));
        Assert.Equal(11, items.Count(i => i.Delivered));
        Assert.Equal(68, items.Count(i => i.SerieSinMovimiento));
        Assert.Equal(68, items.Count(i => i.State == ConsignacionEstado.Vencida));
    }

    [Fact]
    public void OrdenarPorCriticidad_VencidasPrimeroYPorDiasDescendente()
    {
        var items = new List<ItemConsignacion>
        {
            new() { Serial = "E1", State = ConsignacionEstado.Entregado, DaysElapsed = 90 },
            new() { Serial = "P2", State = ConsignacionEstado.EnPlazo, DaysElapsed = 10 },
            new() { Serial = "V1", State = ConsignacionEstado.Vencida, DaysElapsed = 20 },
            new() { Serial = "V2", State = ConsignacionEstado.Vencida, DaysElapsed = 75 },
            new() { Serial = "P1", State = ConsignacionEstado.EnPlazo, DaysElapsed = 25 }
        };

        var orden = ConsignacionesLogic.OrdenarPorCriticidad(items);

        Assert.Equal(new[] { "V2", "V1", "P1", "P2", "E1" }, orden.Select(i => i.Serial).ToArray());
    }

    [Fact]
    public void ComputeEstados_DevuelveLosItemsOrdenadosPorCriticidad()
    {
        var mov = new List<MovimientoConsignacion>
        {
            new() { Serial = "S-ENT", Code = "CI-1", Date = Fecha(100) },
            new() { Serial = "S-PLAZO", Code = "CI-2", Date = Fecha(5) },
            new() { Serial = "S-VENC", Code = "CI-3", Date = Fecha(80) }
        };
        var stock = new List<StockConsignacion>
        {
            new() { Serial = "S-PLAZO", Code = "CI-2", Depto = "301", Qty = 1 },
            new() { Serial = "S-VENC", Code = "CI-3", Depto = "301", Qty = 1 }
        };

        var items = ConsignacionesLogic.ComputeEstados(mov, stock, Plazo30(), Hoy);

        Assert.NotNull(items);
        Assert.Equal(new[] { "S-VENC", "S-PLAZO", "S-ENT" }, items!.Select(i => i.Serial).ToArray());
    }

    [Fact]
    public void ComputeEstados_EndToEnd_OnProduccionOrdenaPorCriticidad()
    {
        var settings = new ConsignacionSettings();

        var movimientos = ConsignacionesLogic.LeerMovimientos(Sample("Movimientos_Produccion.xlsx"), settings);
        var stock = ConsignacionesLogic.LeerStock(Sample("Stock_Produccion.xlsx"), settings);

        var items = ConsignacionesLogic.ComputeEstados(movimientos, stock, settings, new DateTime(2026, 9, 22));

        Assert.NotNull(items);
        Assert.NotEmpty(items!);

        // Los vencidos abren la tabla y dentro de cada estado el que mas dias lleva primero.
        Assert.Equal(ConsignacionEstado.Vencida, items![0].State);
        Assert.Equal(ConsignacionEstado.Entregado, items[^1].State);

        var prioridades = items
            .Select(i => i.State switch
            {
                ConsignacionEstado.Vencida => 0,
                ConsignacionEstado.EnPlazo => 1,
                _ => 2
            })
            .ToList();

        Assert.Equal(prioridades.OrderBy(p => p).ToList(), prioridades);

        foreach (var grupo in items.GroupBy(i => i.State))
        {
            var dias = grupo.Select(i => i.DaysElapsed).ToList();
            Assert.Equal(dias.OrderByDescending(d => d).ToList(), dias);
        }
    }

    private static DateTime Hoy => new(2026, 9, 13);

    private static DateTime Fecha(int daysAgo) => Hoy.AddDays(-daysAgo);

    private static ConsignacionSettings Plazo30() => new() { PlazoLimite = 30 };

    private static ItemConsignacion AssertSingle(List<ItemConsignacion>? items, string serial)
    {
        Assert.NotNull(items);
        var item = Assert.Single(items!);
        Assert.Equal(serial, item.Serial);
        return item;
    }
}