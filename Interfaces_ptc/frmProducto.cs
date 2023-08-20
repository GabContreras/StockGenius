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
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            CargarProv();
            MostrarProductos();
        }
        private void MostrarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Producto.CargarProducto();

        }
        private void CargarProv()
        {
            //Manejo de excepciones 
            //El código que puede dar error
            try
            {
                cbProveedor.DataSource = null;
                cbProveedor.DataSource = Proveedores.CargarProveedores();

                //El valor que se muestra en el combobox
                //Se coloca el nombre de la columna en la tabla
                cbProveedor.DisplayMember = "Nombre";

                //Valor que no se muestra (id)
                //Se coloca el nombre de la columna en la tabla
                cbProveedor.ValueMember = "Id_Proveedor";
            }

            //Bloque de código por si da error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvProductos_DoubleClick(object sender, EventArgs e)
        {
            txtNombre.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
            txtStock.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
            cbProveedor.Text = dgvProductos.CurrentRow.Cells[4].Value.ToString();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto();
            p.Nombre = txtNombre.Text;
            p.Descripcion = txtDescripcion.Text;
            p.Stock = int.Parse(txtStock.Text);
            p.Id_Proveedor = (int)cbProveedor.SelectedValue; 
            if (p.InsertarProducto() == true)
            {
                MessageBox.Show("Producto agregado satisfactoriamente", "Éxito");
                MostrarProductos();
            }
            else
            {
                MessageBox.Show("Se produjo un error", "Advertencia");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvProductos.CurrentRow.Cells[0].Value.ToString());
            Producto p = new Producto();
            if (p.EliminarProducto(id) == true)
            {
                MessageBox.Show("Producto eliminado satisfactoriamente", "Éxito");
                MostrarProductos();
            }
            else
            {
                MessageBox.Show("Se produjo un error", "Advertencia");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto();
            p.Nombre = txtNombre.Text;
            p.Descripcion = txtDescripcion.Text;
            p.Stock = int.Parse(txtStock.Text);
            p.Id_Proveedor = (int)cbProveedor.SelectedValue;
            p.Id_Producto= (int)dgvProductos.CurrentRow.Cells[0].Value;
            if (p.ActualizarProducto() == true)
            {
                MessageBox.Show("Proveedor actualizado satisfactoriamente", "Éxito");
                MostrarProductos();
            }
            else
            {
                MessageBox.Show("Se produjo un error", "Advertencia");
            }
            MostrarProductos();
        }
    }
}
