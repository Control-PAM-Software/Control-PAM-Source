using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Control.Logic;
using Control.Models.Entities;
using Control.Models.Settings;

namespace Control
{
    public partial class FrmReporteBernafon : Form
    {
        private static readonly Color AcentoEnStock = Color.FromArgb(74, 125, 255);
        private static readonly Color AcentoVencidos = Color.FromArgb(214, 69, 88);
        private static readonly Color AcentoEntregados = Color.FromArgb(46, 158, 91);

        private List<ItemConsignacion>? itemsActuales;
        private List<TarjetaInfo> tarjetas = new();
        private TarjetaInfo? tarjetaHover;
        private bool actualizandoFiltros;

        private enum FiltroTarjeta
        {
            EnStock,
            Vencidos,
            Entregados
        }

        private sealed class TarjetaInfo
        {
            public Panel Card { get; init; } = null!;
            public Panel Barra { get; init; } = null!;
            public Label Valor { get; init; } = null!;
            public Label Titulo { get; init; } = null!;
            public FiltroTarjeta Filtro { get; init; }
            public Color Acento { get; init; }
            public Color Fondo { get; init; }
            public Color FondoActivo { get; init; }
            public Color FondoHover { get; init; }
        }

        public FrmReporteBernafon()
        {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            tarjetas = CrearTarjetas();
            foreach (var tarjeta in tarjetas)
            {
                ConfigurarTarjeta(tarjeta);
            }

            cmbEstado.Items.AddRange(new object[] { "Todos", "En Stock", "En Plazo", "Vencidos", "Entregados" });
            cmbEstado.SelectedIndex = 0;

            cmbEstado.SelectedIndexChanged += Filtro_Changed;
            cmbDeposito.SelectedIndexChanged += Filtro_Changed;
            txtBuscar.TextChanged += Filtro_Changed;
        }

        private void Filtro_Changed(object? sender, EventArgs e)
        {
            if (actualizandoFiltros)
            {
                return;
            }

            RefrescarVista();
        }

        private void FrmReporteBernafon_Load(object sender, EventArgs e)
        {
            AlinearCamposDeArchivo();
            RefrescarVista();
        }

        /// <summary>
        /// Acomoda los textboxes de ruta en una misma columna, a la derecha del label más ancho,
        /// de modo que ambos comiencen y terminen alineados sin importar el escalado de pantalla.
        /// </summary>
        private void AlinearCamposDeArchivo()
        {
            const int separacion = 12;
            int izquierda = Math.Max(labelMov.Right, labelStock.Right) + separacion;
            txtMovPath.Left = izquierda;
            txtStockPath.Left = izquierda;
        }

        // Sin esto, al maximizar un formulario MDI hijo, Windows fusiona sus botones de
        // Minimizar/Maximizar/Cerrar en la barra de menú del contenedor. Para conservar una
        // ventana con su propio título debajo del menú, "maximizamos" ajustando el formulario
        // al área del cliente MDI sin cambiar su estado real.
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MAXIMIZE = 0xF030;

        private MdiClient? mdiClient;

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            AjustarAlAreaMdi();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt64() & 0xFFF0) == SC_MAXIMIZE)
            {
                AjustarAlAreaMdi();
                return;
            }

            base.WndProc(ref m);
        }

        private void AjustarAlAreaMdi()
        {
            if (MdiParent is null)
            {
                return;
            }

            mdiClient ??= MdiParent.Controls.OfType<MdiClient>().FirstOrDefault();
            if (mdiClient is null)
            {
                return;
            }

            WindowState = FormWindowState.Normal;
            Bounds = mdiClient.ClientRectangle;

            mdiClient.Resize -= MdiClient_Resize;
            mdiClient.Resize += MdiClient_Resize;
        }

        private void MdiClient_Resize(object? sender, EventArgs e)
        {
            if (mdiClient is not null && WindowState == FormWindowState.Normal)
            {
                Bounds = mdiClient.ClientRectangle;
            }
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                string movPath = txtMovPath.Text.Trim();
                string stockPath = txtStockPath.Text.Trim();

                if (string.IsNullOrEmpty(movPath) || string.IsNullOrEmpty(stockPath))
                {
                    MessageBox.Show("Debe seleccionar el Listado de Movimientos de Stock y el Listado de Stock Actual.",
                        "Faltan archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ConsignacionSettings settings = AppSettings.settings.ConsignacionReporte;

                var movimientos = ConsignacionesLogic.LeerMovimientos(movPath, settings);
                if (movimientos == null)
                {
                    MessageBox.Show("No se pudo leer el Listado de Movimientos de Stock. Verifique que las columnas configuradas coincidan con el archivo.",
                        "Error de lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var stock = ConsignacionesLogic.LeerStock(stockPath, settings);
                if (stock == null)
                {
                    MessageBox.Show("No se pudo leer el Listado de Stock Actual. Verifique que las columnas configuradas coincidan con el archivo.",
                        "Error de lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var items = ConsignacionesLogic.ComputeEstados(movimientos, stock, settings, DateTime.Today);
                if (items == null)
                {
                    MessageBox.Show("No se pudo calcular el reporte.", "Error al procesar",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                itemsActuales = items;
                ReiniciarFiltros(items);
                ActualizarTarjetas(items);
                RefrescarVista();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al generar el reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillGrid(List<ItemConsignacion> items)
        {
            dataGridView1.Rows.Clear();

            foreach (var item in items)
            {
                int rowIndex = dataGridView1.Rows.Add();

                dataGridView1.Rows[rowIndex].Cells["colSerial"].Value = item.Serial;
                dataGridView1.Rows[rowIndex].Cells["colCode"].Value = item.Code;
                dataGridView1.Rows[rowIndex].Cells["colDepot"].Value = item.CurrentDepot;
                dataGridView1.Rows[rowIndex].Cells["colFecha"].Value = item.DepartureDate;
                dataGridView1.Rows[rowIndex].Cells["colDias"].Value = item.DaysElapsed;
                dataGridView1.Rows[rowIndex].Cells["colEntregado"].Value = item.Delivered ? "Sí" : "No";
                dataGridView1.Rows[rowIndex].Cells["colEstado"].Value = EstadoText(item.State);

                var row = dataGridView1.Rows[rowIndex];

                if (item.SerieSinMovimiento)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 249, 230);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = item.State switch
                    {
                        ConsignacionEstado.EnPlazo => Color.FromArgb(255, 243, 205),
                        ConsignacionEstado.Entregado => Color.FromArgb(212, 237, 218),
                        _ => Color.FromArgb(248, 215, 218)
                    };
                }

                row.Cells["colEstado"].Style.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
                row.Cells["colDias"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Cells["colEntregado"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private static string EstadoText(ConsignacionEstado estado)
        {
            return ConsignacionesLogic.EstadoTexto(estado);
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            ExportarReporte(excel: true);
        }

        private void BtnPdf_Click(object sender, EventArgs e)
        {
            ExportarReporte(excel: false);
        }

        private void ExportarReporte(bool excel)
        {
            List<ItemConsignacion> visibles = ItemsVisibles();

            if (visibles.Count == 0)
            {
                MessageBox.Show(MensajeSinDatos(), "Sin datos para exportar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string extension = excel ? "xlsx" : "pdf";
            using var dialogo = new SaveFileDialog
            {
                Filter = excel ? "Libro de Excel (*.xlsx)|*.xlsx" : "Documento PDF (*.pdf)|*.pdf",
                FileName = $"Reporte_Bernafon_{DateTime.Today:yyyyMMdd}.{extension}",
                Title = excel ? "Exportar reporte a Excel" : "Exportar reporte a PDF",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            if (dialogo.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                if (excel)
                {
                    ConsignacionExcelExporter.Exportar(visibles, dialogo.FileName, DateTime.Today);
                }
                else
                {
                    ConsignacionPdfExporter.Exportar(visibles, dialogo.FileName, DateTime.Today);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo exportar el reporte:\n\n{ex.Message}",
                    "Error de exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Exportación exitosa. ¿Desea abrir el archivo?",
                excel ? "Excel" : "PDF",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(dialogo.FileName)
                {
                    UseShellExecute = true
                });
            }
        }

        private string MensajeSinDatos()
        {
            if (itemsActuales == null)
            {
                return "Todavía no hay datos en pantalla.\nGenere el reporte con el botón \"Generar Reporte\" y vuelva a intentar la exportación.";
            }

            if (itemsActuales.Count == 0)
            {
                return "El reporte no contiene datos para exportar.\nVerifique los archivos de entrada y vuelva a generar el reporte.";
            }

            return "Ninguna de las series del reporte coincide con los filtros actuales.\nQuite los filtros con el botón \"Limpiar\" o cambie la selección para exportar datos.";
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtMovPath.Clear();
            txtStockPath.Clear();
            itemsActuales = null;
            ReiniciarFiltros(null);
            ActualizarTarjetas(null);
            RefrescarVista();
        }

        private void ReiniciarFiltros(List<ItemConsignacion>? items)
        {
            actualizandoFiltros = true;

            txtBuscar.Clear();
            cmbEstado.SelectedIndex = 0;

            string deptoSeleccionado = cmbDeposito.SelectedItem?.ToString() ?? "Todos";
            cmbDeposito.Items.Clear();
            cmbDeposito.Items.Add("Todos");
            if (items != null)
            {
                foreach (string depto in items.Select(i => i.CurrentDepot)
                                              .Where(d => !string.IsNullOrWhiteSpace(d))
                                              .Distinct()
                                              .OrderBy(d => d, StringComparer.Ordinal))
                {
                    cmbDeposito.Items.Add(depto);
                }
            }

            cmbDeposito.SelectedItem = cmbDeposito.Items.Contains(deptoSeleccionado) ? deptoSeleccionado : "Todos";

            bool hayDatos = items != null;
            cmbEstado.Enabled = cmbDeposito.Enabled = txtBuscar.Enabled = hayDatos;

            actualizandoFiltros = false;
        }

        private List<TarjetaInfo> CrearTarjetas()
        {
            return new List<TarjetaInfo>
            {
                new TarjetaInfo
                {
                    Card = pnlCardEnStock,
                    Barra = barAccentEnStock,
                    Valor = lblValorEnStock,
                    Titulo = lblTituloEnStock,
                    Filtro = FiltroTarjeta.EnStock,
                    Acento = AcentoEnStock,
                    Fondo = Color.FromArgb(240, 244, 255),
                    FondoActivo = Color.FromArgb(222, 232, 255),
                    FondoHover = Color.FromArgb(230, 238, 255)
                },
                new TarjetaInfo
                {
                    Card = pnlCardVencidos,
                    Barra = barAccentVencidos,
                    Valor = lblValorVencidos,
                    Titulo = lblTituloVencidos,
                    Filtro = FiltroTarjeta.Vencidos,
                    Acento = AcentoVencidos,
                    Fondo = Color.FromArgb(253, 240, 241),
                    FondoActivo = Color.FromArgb(250, 224, 228),
                    FondoHover = Color.FromArgb(251, 232, 234)
                },
                new TarjetaInfo
                {
                    Card = pnlCardEntregados,
                    Barra = barAccentEntregados,
                    Valor = lblValorEntregados,
                    Titulo = lblTituloEntregados,
                    Filtro = FiltroTarjeta.Entregados,
                    Acento = AcentoEntregados,
                    Fondo = Color.FromArgb(238, 249, 242),
                    FondoActivo = Color.FromArgb(221, 242, 228),
                    FondoHover = Color.FromArgb(230, 245, 235)
                }
            };
        }

        private void ConfigurarTarjeta(TarjetaInfo tarjeta)
        {
            System.Windows.Forms.Control[] objetivos = new System.Windows.Forms.Control[1 + tarjeta.Card.Controls.Count];
            objetivos[0] = tarjeta.Card;
            tarjeta.Card.Controls.CopyTo(objetivos, 1);

            foreach (System.Windows.Forms.Control control in objetivos)
            {
                control.Cursor = Cursors.Hand;
                control.Click += (s, e) => AlternarFiltro(tarjeta.Filtro);
                control.MouseEnter += (s, e) =>
                {
                    tarjetaHover = tarjeta;
                    PintarTarjetas();
                };
                control.MouseLeave += (s, e) =>
                {
                    if (ReferenceEquals(tarjetaHover, tarjeta))
                    {
                        tarjetaHover = null;
                        PintarTarjetas();
                    }
                };
            }

            toolTip1.SetToolTip(tarjeta.Card, "Haga clic para mostrar solo esta información y otra vez para volver a ver todo.");
        }

        private static string EtiquetaFiltro(FiltroTarjeta filtro)
        {
            return filtro switch
            {
                FiltroTarjeta.EnStock => "En Stock",
                FiltroTarjeta.Vencidos => "Vencidos",
                _ => "Entregados"
            };
        }

        private void AlternarFiltro(FiltroTarjeta filtro)
        {
            string etiqueta = EtiquetaFiltro(filtro);
            cmbEstado.SelectedItem = string.Equals(cmbEstado.SelectedItem?.ToString(), etiqueta, StringComparison.Ordinal)
                ? "Todos"
                : etiqueta;
        }

        private bool HayFiltroActivo
        {
            get
            {
                return (cmbEstado.SelectedItem?.ToString() != "Todos")
                    || (cmbDeposito.SelectedItem?.ToString() != "Todos")
                    || !string.IsNullOrWhiteSpace(txtBuscar.Text);
            }
        }

        private bool AplicaFiltro(ItemConsignacion item)
        {
            return AplicaFiltroEstado(item)
                && AplicaFiltroDeposito(item)
                && AplicaFiltroBusqueda(item);
        }

        private bool AplicaFiltroEstado(ItemConsignacion item)
        {
            return (cmbEstado.SelectedItem?.ToString() ?? "Todos") switch
            {
                "En Stock" => !string.IsNullOrWhiteSpace(item.CurrentDepot),
                "En Plazo" => item.State == ConsignacionEstado.EnPlazo,
                "Vencidos" => item.State == ConsignacionEstado.Vencida,
                "Entregados" => item.State == ConsignacionEstado.Entregado,
                _ => true
            };
        }

        private bool AplicaFiltroDeposito(ItemConsignacion item)
        {
            string depto = cmbDeposito.SelectedItem?.ToString() ?? "Todos";
            return depto == "Todos" || string.Equals(item.CurrentDepot, depto, StringComparison.Ordinal);
        }

        private bool AplicaFiltroBusqueda(ItemConsignacion item)
        {
            string busqueda = txtBuscar.Text.Trim();
            if (busqueda.Length == 0)
            {
                return true;
            }

            return item.Serial.Contains(busqueda, StringComparison.OrdinalIgnoreCase)
                || item.Code.Contains(busqueda, StringComparison.OrdinalIgnoreCase);
        }

        private List<ItemConsignacion> ItemsVisibles()
        {
            return itemsActuales == null
                ? new List<ItemConsignacion>()
                : itemsActuales.Where(AplicaFiltro).ToList();
        }

        private void RefrescarVista()
        {
            PintarTarjetas();

            List<ItemConsignacion> visibles = ItemsVisibles();

            ActualizarContadorMeta(visibles.Count);
            FillGrid(visibles);
        }

        private void ActualizarContadorMeta(int visibles)
        {
            int total = itemsActuales?.Count ?? 0;
            string linea = total == 0
                ? "Sin datos cargados"
                : !HayFiltroActivo
                    ? $"Series: {total}"
                    : $"Mostrando {visibles} de {total} series";

            lblMeta.Text = $"Fecha de corte: {DateTime.Today:dd/MM/yyyy}\nDepósito origen: 200\n{linea}";
        }

        private void ActualizarTarjetas(List<ItemConsignacion>? items)
        {
            int enStock = items?.Count(i => !string.IsNullOrWhiteSpace(i.CurrentDepot)) ?? 0;
            int enPlazo = items?.Count(i => i.State == ConsignacionEstado.EnPlazo) ?? 0;
            int vencidos = items?.Count(i => i.State == ConsignacionEstado.Vencida) ?? 0;
            int entregados = items?.Count(i => i.State == ConsignacionEstado.Entregado) ?? 0;

            lblValorEnStock.Text = enStock.ToString();
            lblDetalleEnStock.Text = $"{enPlazo} en plazo · {vencidos} {Plural(vencidos, "vencida", "vencidas")}";

            lblValorVencidos.Text = vencidos.ToString();
            lblDetalleVencidos.Text = vencidos == 0
                ? "Sin consignaciones vencidas"
                : $"{Plural(vencidos, "Requiere", "Requieren")} seguimiento";

            lblValorEntregados.Text = entregados.ToString();
            lblDetalleEntregados.Text = "Ya no están en depósito";
        }

        private void PintarTarjetas()
        {
            foreach (TarjetaInfo tarjeta in tarjetas)
            {
                bool activa = string.Equals(cmbEstado.SelectedItem?.ToString(),
                    EtiquetaFiltro(tarjeta.Filtro), StringComparison.Ordinal);

                tarjeta.Card.BackColor = activa
                    ? tarjeta.FondoActivo
                    : ReferenceEquals(tarjetaHover, tarjeta) ? tarjeta.FondoHover : tarjeta.Fondo;

                tarjeta.Barra.BackColor = activa ? tarjeta.Acento : ControlPaint.Light(tarjeta.Acento, 0.1F);
                tarjeta.Barra.Width = activa ? 7 : 5;
                tarjeta.Valor.ForeColor = activa ? tarjeta.Acento : Color.FromArgb(31, 31, 58);
                tarjeta.Titulo.ForeColor = activa ? tarjeta.Acento : Color.FromArgb(90, 90, 108);
            }
        }

        private static string Plural(int cantidad, string singular, string plural)
        {
            return cantidad == 1 ? singular : plural;
        }

        private void btnExaminarMov_Click(object sender, EventArgs e)
        {
            ExaminarMov();
        }

        private void btnExaminarStock_Click(object sender, EventArgs e)
        {
            ExaminarStock();
        }

        private void ExaminarMov()
        {
            string? ruta = SeleccionarExcel();
            if (ruta != null)
            {
                txtMovPath.Text = ruta;
            }
        }

        private void ExaminarStock()
        {
            string? ruta = SeleccionarExcel();
            if (ruta != null)
            {
                txtStockPath.Text = ruta;
            }
        }

        private string? SeleccionarExcel()
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Archivos Excel (*.xls;*.xlsx)|*.xls;*.xlsx"
            };

            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : null;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Functions.EnumerarFilasDataGrid(sender, e);
        }
    }
}