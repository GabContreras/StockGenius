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
            dgvProductos.DataSource = Producto.CargarProducto();
            dgvProductos.Columns[2].Visible = false;
            dgvProductos.Columns[6].Visible = false;
            dgvProductos.Columns[7].Visible = false;

        }
        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }
        private void Actualizar()
        {
            dgvProductos.DataSource = Producto.Buscar(txtBuscar.Text);
        }
       
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }
    }
}
