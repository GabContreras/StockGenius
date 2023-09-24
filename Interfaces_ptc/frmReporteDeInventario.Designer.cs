namespace Interfaces_ptc
{
    partial class frmReporteDeInventario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteDeInventario));
            this.rpInventario = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpInventario
            // 
            this.rpInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpInventario.LocalReport.ReportEmbeddedResource = "Interfaces_ptc.Report1.rdlc";
            this.rpInventario.Location = new System.Drawing.Point(0, 0);
            this.rpInventario.Margin = new System.Windows.Forms.Padding(4);
            this.rpInventario.Name = "rpInventario";
            this.rpInventario.ServerReport.BearerToken = null;
            this.rpInventario.Size = new System.Drawing.Size(768, 450);
            this.rpInventario.TabIndex = 1;
            // 
            // frmReporteDeInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 450);
            this.Controls.Add(this.rpInventario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmReporteDeInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de movimiento de inventario";
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpInventario;
    }
}