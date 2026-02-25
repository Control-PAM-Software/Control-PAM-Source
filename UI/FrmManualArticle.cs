using Control.Logic;
using Control.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control
{
    /*
     Esta ventana está especialmente diseñada para artículos que vienen varias unidades por caja. Al abrir una caja queda cantidad parcial (no total de la caja), por lo que el usuario puede cargar las unidades parciales que le queden.
    Este form se reutiliza en todas las líneas.
     */
    public partial class FrmManualArticle : Form
    {
        public string articleCode;
        public string articleSerie;
        public string articleDueDate;
        public string articleQuantity;
        public eProductLine productLine;
        private bool doublePick = false; // Se setea en true cuando el se debe ingresar código y número de serie por separado.

        // Lista para trackear qué controles tienen error
        private HashSet<System.Windows.Forms.Control> invalidControls = new HashSet<System.Windows.Forms.Control>();
        private ToolTip validationToolTip = new ToolTip();

        public FrmManualArticle()
        {
            InitializeComponent();
        }
        private void FrmManualArticle_Load(object sender, EventArgs e)
        {
            txtCodeInputUser.Focus();

            switch (productLine)
            {
                case eProductLine.Oticom:
                case eProductLine.AB:
                    lblSerieInput.Visible = true;
                    txtSerieInputUser.Visible = true;
                    doublePick = true;
                    break;
                case eProductLine.Bernafon:
                case eProductLine.Inomed:
                case eProductLine.Atos:
                    lblSerieInput.Visible = false;
                    txtSerieInputUser.Visible = false;
                    break;

            }

            dtpDueDate.Value = dtpDueDate.MinDate;

        }

        private void txtInputUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                // Si la linea de doble pickeo, entonces focus al número de serie y no hago nada en esta función.
                if (doublePick)
                {
                    txtSerieInputUser.Focus();
                    return;
                }

                string codeInput = txtCodeInputUser.Text.Trim().ToUpper();

                if (!string.IsNullOrEmpty(codeInput))
                {
                    ItemAnexo? itemInput = Functions.GetItemFromInput(codeInput, productLine);

                    if (itemInput == null)
                    {
                        MessageBox.Show("Formato de cadena de texto incorrecto.", "Error de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    FillItemInformation(itemInput);
                }
            }
        }

        private void txtSerieInputUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                string codeInput = txtCodeInputUser.Text.Trim().ToUpper();
                string serieInput = txtSerieInputUser.Text.Trim().ToUpper();

                if (string.IsNullOrEmpty(codeInput) || string.IsNullOrEmpty(serieInput))
                    return;

                ItemAnexo? itemInput = Functions.GetItemFromInput(codeInput, serieInput, productLine);

                if (itemInput == null)
                {
                    MessageBox.Show("Formato de cadena de texto incorrecto.", "Error de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FillItemInformation(itemInput);
            }
        }

        private void FillItemInformation(ItemAnexo itemAnexo)
        {
            TxtCode.Text = itemAnexo.CodItem;
            txtSerie.Text = itemAnexo.SerialNumber;
            txtQuantity.Text = itemAnexo.Quantity.ToString();
            //txtDueDate.Text = itemAnexo.DueDate;

            if (!string.IsNullOrWhiteSpace(itemAnexo.DueDate) &&
                DateTime.TryParseExact(
                    itemAnexo.DueDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime dueDate))
            {
                dtpDueDate.Value = dueDate;
            }
            else
            {
                dtpDueDate.Value = dtpDueDate.MinDate;
            }

            txtCodeInputUser.Clear();
            txtSerieInputUser.Clear();
            txtCodeInputUser.Focus();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            CloseFrm();
        }

        private void CloseFrm()
        {
            if (!ValidateInputs())
                return;

            articleCode = TxtCode.Text;
            articleSerie = txtSerie.Text;
            articleQuantity = txtQuantity.Text;
            articleDueDate = "";

            if (dtpDueDate.Value != dtpDueDate.MinDate)
            {
                articleDueDate = dtpDueDate.Value.Date.ToString("dd/MM/yyyy");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            // Validación Código
            if (string.IsNullOrWhiteSpace(TxtCode.Text))
            {
                SetErrorStyle(TxtCode, "El código de artículo es obligatorio.");
                isValid = false;
            }
            else SetErrorStyle(TxtCode, "");

            // Validación Serie
            if (string.IsNullOrWhiteSpace(txtSerie.Text))
            {
                SetErrorStyle(txtSerie, "El número de serie es obligatorio.");
                isValid = false;
            }
            else SetErrorStyle(txtSerie, "");

            // Validación Cantidad
            if (!int.TryParse(txtQuantity.Text, out int q) || q <= 0)
            {
                SetErrorStyle(txtQuantity, "Ingrese una cantidad válida mayor a 0.");
                isValid = false;
            }
            else SetErrorStyle(txtQuantity, "");

            return isValid;
        }
        private void SetErrorStyle(System.Windows.Forms.Control ctrl, string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                invalidControls.Add(ctrl);
                validationToolTip.SetToolTip(ctrl, message);
                // Forzamos al control a redibujarse
                ctrl.Invalidate();
            }
            else
            {
                invalidControls.Remove(ctrl);
                validationToolTip.SetToolTip(ctrl, "");
                ctrl.Invalidate();
            }

            // Si el control es un TextBox, necesitamos redibujar el área del padre 
            // porque el borde se dibuja "afuera" del control
            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (var ctrl in invalidControls)
            {
                if (ctrl.Visible)
                {
                    // Definimos el área del borde (un poco más grande que el control)
                    Rectangle rect = ctrl.Bounds;
                    rect.Inflate(1, 1);

                    // Dibujamos una sombra suave (opcional)
                    using (Pen shadowPen = new Pen(Color.FromArgb(50, Color.Red), 4))
                    {
                        e.Graphics.DrawRectangle(shadowPen, rect);
                    }

                    // Dibujamos el borde rojo sólido
                    using (Pen errorPen = new Pen(Color.Red, 1))
                    {
                        e.Graphics.DrawRectangle(errorPen, rect);
                    }
                }
            }
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.Control ctrl = (System.Windows.Forms.Control)sender;
            if (invalidControls.Contains(ctrl))
            {
                SetErrorStyle(ctrl, ""); // Quita el rojo mientras escribe
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
