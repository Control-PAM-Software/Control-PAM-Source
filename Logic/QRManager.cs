using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using QRCoder;

namespace Control.Logic
{
    public class QRManager
    {
        // Configuración de la etiqueta (SATO 10x6 cm)
        private const int LabelWidth = 236;
        private const int LabelHeight = 394;
        private const int OffsetLeft = 5;
        private const int OffsetTop = 5;

        public void ImprimirEtiquetaValija(string nombre, string apellido, string serie, List<object> items)
        {
            try
            {
                // 1. Preparar datos (Compresión interna)
                string jsonCompacto = SerializarYComprimir(items);

                // 2. Configurar Documento de Impresión
                PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.PaperSize = new PaperSize("SATO_10x6", LabelWidth, LabelHeight);
                pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                pd.OriginAtMargins = true;

                pd.PrintPage += (s, e) =>
                {
                    RenderizarEtiqueta(e.Graphics, nombre, apellido, serie, jsonCompacto);
                };

                // 3. Mostrar Vista Previa
                using (PrintPreviewDialog ppd = new PrintPreviewDialog())
                {
                    ppd.Document = pd;
                    ppd.WindowState = FormWindowState.Maximized;
                    ppd.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en QRManager: {ex.Message}");
            }
        }

        private string SerializarYComprimir(List<object> items)
        {
            // El mapeo a 'c', 's', 'q', 'v' se hace aquí para que el Form no sepa de esto
            var compactList = items.Select(i =>
            {
                // Usamos dynamic o reflexión para obtener las propiedades del objeto genérico
                dynamic item = i;
                return new
                {
                    c = item.CodItem,
                    s = item.SerialNumber,
                    q = item.Quantity,
                    v = item.DueDate
                };
            }).ToList();

            string json = JsonConvert.SerializeObject(compactList, Formatting.None);

            // Lógica de compresión GZip
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(json);
            using (var ms = new MemoryStream())
            {
                using (var zip = new GZipStream(ms, CompressionMode.Compress))
                {
                    zip.Write(buffer, 0, buffer.Length);
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        private void RenderizarEtiqueta(Graphics g, string nombre, string apellido, string serie, string jsonContent)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            // Fuentes
            Font fontLabel = new Font("Arial", 8, FontStyle.Bold);
            Font fontData = new Font("Arial", 10, FontStyle.Regular);
            Font fontTitle = new Font("Arial", 12, FontStyle.Bold);

            int startX = OffsetLeft + 20;
            int currentY = OffsetTop + 30;
            bool drawLine = false;

            // Dibujar Textos
            if (!string.IsNullOrEmpty(nombre))
            {
                g.DrawString("PACIENTE", fontLabel, Brushes.Gray, startX, currentY);
                g.DrawString($"{nombre} {apellido}".ToUpper(), fontTitle, Brushes.Black, startX, currentY + 15);
                currentY += 65;
                drawLine = true;
            }

            if (!string.IsNullOrEmpty(serie))
            {
                g.DrawString("NÚMERO DE SERIE", fontLabel, Brushes.Gray, startX, currentY);
                g.DrawString(serie, fontData, Brushes.Black, startX, currentY + 15);
                currentY += 50;
                drawLine = true;
            }

            if (drawLine)
            {
                g.DrawLine(Pens.LightGray, startX, currentY, LabelWidth - 35, currentY);
                currentY += 20;
            }

            // Generar y Dibujar QR
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrData = qrGenerator.CreateQrCode(jsonContent, QRCodeGenerator.ECCLevel.L);
            QRCode qrCode = new QRCode(qrData);

            using (Bitmap qrImage = qrCode.GetGraphic(5))
            {
                int qrSize = 180;
                int qrX = (LabelWidth / 2) - (qrSize / 2);
                g.DrawImage(qrImage, new Rectangle(qrX, currentY, qrSize, qrSize));
            }
        }
    }
}