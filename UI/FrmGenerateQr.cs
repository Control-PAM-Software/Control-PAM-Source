using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control
{
    public partial class FrmGenerateQr : Form
    {
        public string serialNumber = "";

        public string nameCustomer => txtName.Text;
        public string lastNameCustomer => txtLastName.Text;
        public string serialNumer => txtSerie.Text;

        public FrmGenerateQr()
        {
            InitializeComponent();
        }

        private void FrmGenerateQr_Load(object sender, EventArgs e)
        {
            txtSerie.Text = serialNumber;
        }

        private void btnGenerateQr_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
