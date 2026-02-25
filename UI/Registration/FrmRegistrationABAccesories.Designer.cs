using System.Drawing.Printing;
using System.Windows.Forms;

namespace Control
{
    partial class FrmRegistrationABAccesories
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistrationABAccesories));
            // 
            // FrmRegistrationABAccesories
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1207, 588);
            Font = new Font("Segoe UI Semibold", 9F);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmRegistrationABAccesories";
            Text = "Ingreso Accesorios";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            dataGridView1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReceived).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
