using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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
            Actualizar();
            MostrarProductos();

        }
        
        private void MostrarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Producto.CargarProducto();
            dgvProductos.Columns[6].Visible = false;
            dgvProductos.Columns[7].Visible = false;

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
        private void LimpiarCampo()
        {
            txtCantidad.Text = "";
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int Id_producto = (int)dgvProductos.CurrentRow.Cells[0].Value;
                int Id_proveedor = (int)dgvProductos.CurrentRow.Cells[7].Value;
                IngresoProducto IP = new IngresoProducto();

                string estadoProveedor = IP.ObtenerEstadoProveedor(Id_proveedor);

                if (estadoProveedor.Equals("Inactivo"))
                {
                    MessageBox.Show("No se puede agregar stock a si el proveedor está inactivo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; // No continuar la ejecución del código
                }
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("no dejar campos vacíos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (txtCantidad.Text == "0")
                {
                    MessageBox.Show("Ingrese una cantidad válida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    int Cantidad = int.Parse(txtCantidad.Text);
                    IP.Id_producto = Id_producto;
                    IP.Fecha_ingreso = DateTime.Now;
                    IP.Cantidad = Cantidad;
                    if (IP.ingresarProducto() == true)
                    {
                        Producto p = new Producto();
                        int StockActual = (int)dgvProductos.CurrentRow.Cells[3].Value;
                        p.Id_Producto = Id_producto;
                        p.Stock = Cantidad + StockActual;
                        if (p.ActualizarProducto2() == true)
                        {
                            MessageBox.Show("Stock actualizado satisfactoriamente", "Éxito");
                            MostrarProductos();
                            LimpiarCampo();
                        }
                        else
                        {
                            MessageBox.Show("Se produjo un error", "Advertencia");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se produjo un error", "Advertencia");
                    }
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Por favor, seleccione un producto antes de ingresar stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter es un número
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Solo números son permitidos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }
    }
}
