using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Modelos;

namespace Interfaces_ptc
{
    public partial class frmFactura : Form
    {
        public frmFactura(int idV)
        {
            InitializeComponent();
            rpFactura.LocalReport.DataSources.Clear();
            DetallePedido dp= new DetallePedido();
            dp.Id_pedido= idV;
            DataTable dt= dp.CargarFactura();
            ReportDataSource rp= new ReportDataSource("DataSet1",dt);
            rpFactura.LocalReport.DataSources.Add(rp);
            rpFactura.RefreshReport();
            rpFactura.ZoomMode = ZoomMode.FullPage;
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {

    
        }
    }
}
