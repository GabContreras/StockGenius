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
    public partial class frmPedido : Form
    {
        public frmPedido()
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

        private void frmPedido_Load(object sender, EventArgs e)
        {
            MostrarPedido();
        }
        private void MostrarPedido()
        {
            dgvPedido.DataSource = null;
            dgvPedido.DataSource = Pedido.CargarPedido();

        }
    }
}
