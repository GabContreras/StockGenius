using Microsoft.Reporting.WinForms;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaces_ptc
{
    public partial class frmReporteDeInventario : Form
    {
        public frmReporteDeInventario(DateTime fechaInicio, DateTime fechaFin)
        {
            InitializeComponent();
            rpInventario.LocalReport.DataSources.Clear();
            Producto pr = new Producto();       

            // Obtener los datos del informe llamando a tu método GenerarInformeInventario
            // pasando las fechas de inicio y fin como parámetros
            DataTable dt = pr.GenerarInformeInventario(fechaInicio, fechaFin);

            // Establecer el origen de datos del informe
            ReportDataSource rp = new ReportDataSource("DataSet1", dt);
            rpInventario.LocalReport.DataSources.Add(rp);

            // Refrescar y mostrar el informe en el control ReportViewer
            rpInventario.RefreshReport();
            rpInventario.ZoomMode = ZoomMode.PageWidth;

        }

        private void frmReporteDeInventario_Load(object sender, EventArgs e)
        {
           
        }

        

    }
}
