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
    public partial class frmAgregarProductos : Form
    {
        public frmAgregarProductos(Usuario u)
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAgregarProductos_Load(object sender, EventArgs e)
        {
            MostrarProductos();

        }
        
        private void MostrarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Producto.CargarProducto();
            dgvProductos.Columns[6].Visible = false;
        }
        private void Actualizar()
        {
            dgvProductos.DataSource = Producto.Buscar(txtBuscar.Text);
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }
      
    private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto();
            int StockActual= (int)dgvProductos.CurrentRow.Cells[3].Value;
            p.Id_Producto = (int)dgvProductos.CurrentRow.Cells[0].Value;
            p.Stock = int.Parse(txtCantidad.Text)+ StockActual;
            if (p.ActualizarProducto2() == true)
            {
                MessageBox.Show("Producto actualizado satisfactoriamente", "Éxito");
                MostrarProductos();
            }
            else
            {
                MessageBox.Show("Se produjo un error", "Advertencia");
            }
        }
    }
}
