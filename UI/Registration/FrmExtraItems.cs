using Control.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control.UI.Registration
{
    public partial class FrmExtraItems : Form
    {
        public List<ItemAnexo> Extras { get; private set; }

        public FrmExtraItems(List<ItemAnexo> extraItems)
        {
            InitializeComponent();
            this.Extras = extraItems;
            ConfigurarGrid();
            CargarDatos();
        }

        private void ConfigurarGrid()
        {
            dgvExtras.AutoGenerateColumns = false;
            dgvExtras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CodItem", HeaderText = "Código", Name = "CodItem" });
            dgvExtras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Description", HeaderText = "Descripción", Name = "Description" });
            dgvExtras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SerialNumber", HeaderText = "Serie", Name = "SerialNumber" });
            dgvExtras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Cant.", Name = "Quantity" });
            dgvExtras.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DueDate", HeaderText = "Vencimiento", Name = "DueDate" });
        }

        private void CargarDatos()
        {
            dgvExtras.DataSource = null;
            dgvExtras.DataSource = Extras;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnInclude_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
