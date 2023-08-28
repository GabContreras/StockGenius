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
    public partial class frmStock : Form
    {
        public frmStock()
        {
           InitializeComponent();
        }
        private void MostrarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Producto.CargarStock();

        }
        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }
    }
}
