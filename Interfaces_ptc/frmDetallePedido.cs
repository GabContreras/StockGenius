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
    public partial class frmDetallePedido : Form
    {
        public frmDetallePedido()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetallePedido_Load(object sender, EventArgs e)
        {
            MostrarDetallePedido();
        }
        private void MostrarDetallePedido()
        {
            dgvDetallePedido.DataSource = null;
            dgvDetallePedido.DataSource = DetallePedido.CargarDetallePedido();

        }
    }
}
