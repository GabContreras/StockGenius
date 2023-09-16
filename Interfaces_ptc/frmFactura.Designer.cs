namespace Interfaces_ptc
{
    partial class frmFactura
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
            this.rpFactura = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpFactura
            // 
            this.rpFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpFactura.LocalReport.ReportEmbeddedResource = "Interfaces_ptc.Report1.rdlc";
            this.rpFactura.Location = new System.Drawing.Point(0, 0);
            this.rpFactura.Margin = new System.Windows.Forms.Padding(4);
            this.rpFactura.Name = "rpFactura";
            this.rpFactura.ServerReport.BearerToken = null;
            this.rpFactura.Size = new System.Drawing.Size(832, 749);
            this.rpFactura.TabIndex = 0;
            // 
            // frmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(832, 749);
            this.Controls.Add(this.rpFactura);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.frmFactura_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpFactura;
    }
}