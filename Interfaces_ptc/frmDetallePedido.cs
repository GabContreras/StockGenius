using Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
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
            CargarPed();
            cargarProd();

            Actualizar();
            cbPedido.SelectedIndex = -1;
            cbProducto.SelectedIndex = -1;
        }
        private void MostrarDetallePedido()
        {
            //Se carga el DGV en base al ID de venta seleccionado
            dgvDetallePedido.DataSource = null;

            DetallePedido dp = new DetallePedido();
            dp.Id_pedido = int.Parse(cbPedido.Text);

            dgvDetallePedido.DataSource = dp.CargarDetallePedido();
            dgvDetallePedido.Columns[0].Visible = false;

    
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
        private void CargarPed()
        {
            //Manejo de excepciones 
            //El código que puede dar error
            try
            {
                cbPedido.DataSource = null;
                cbPedido.DataSource = Pedido.CargarPedido();

                //El valor que se muestra en el combobox
                //Se coloca el nombre de la columna en la tabla
                cbPedido.DisplayMember = "Id_Pedido";
            }

            //Bloque de código por si da error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cargarProd()
        {
            //Manejo de excepciones 
            //El código que puede dar error
            try
            {
                cbProducto.DataSource = null;
                cbProducto.DataSource = Producto.CargarProducto();

                //El valor que se muestra en el combobox
                //Se coloca el nombre de la columna en la tabla
                cbProducto.DisplayMember = "Nombre";

                //Valor que no se muestra (id)
                //Se coloca el nombre de la columna en la tabla
                cbProducto.ValueMember = "Id_Producto";
            }

            //Bloque de código por si da error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDetallePedido_DoubleClick(object sender, EventArgs e)
        {
            cbPedido.Text = dgvDetallePedido.CurrentRow.Cells[1].Value.ToString();
            cbProducto.Text = dgvDetallePedido.CurrentRow.Cells[3].Value.ToString();
            txtCantidad.Text = dgvDetallePedido.CurrentRow.Cells[4].Value.ToString();
            
        }
        private void LimpiarCampo()
        {
            txtCantidad.Text = "";
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("No dejar campos vacios",
                   "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cbPedido.SelectedIndex < 0)
                {
                    MessageBox.Show("Escoja un número de pedido primero");
                }
                else if (cbProducto.SelectedIndex < 0)
                {
                    MessageBox.Show("Escoja un producto primero");
                }
                else
                {
                    DetallePedido p = new DetallePedido();
                    Producto pp = new Producto();

                    p.Id_pedido = int.Parse(cbPedido.Text);
                    p.Id_Producto = (int)cbProducto.SelectedValue;
                    p.Cantidad = int.Parse(txtCantidad.Text);
                    p.Total = ((int.Parse(txtCantidad.Text)) * pp.ObtenerPrecioProducto(p.Id_Producto));
                    // Se obtiene la cantidad en stock actual
                    int stockActual = pp.ObtenerStockProducto(p.Id_Producto);

                    if (stockActual >= p.Cantidad) // Se verifica si la cantidad excede el stock
                    {
                        if (p.InsertarDpedido() == true)
                        {
                            MessageBox.Show("Detalle agregado satisfactoriamente", "Éxito");
                            MostrarDetallePedido();
                            LimpiarCampo();
                        }
                        else
                        {
                            MessageBox.Show("Se produjo un error", "Advertencia");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad solicitada excede el stock disponible", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dgvDetallePedido.CurrentRow.Cells[0].Value.ToString());
                DetallePedido p = new DetallePedido();
                if (p.EliminarDetallePedido(id) == true)
                {
                    MessageBox.Show("Producto eliminado satisfactoriamente", "Éxito");
                    MostrarDetallePedido();
                    LimpiarCampo();
                }
                else
                {
                    MessageBox.Show("Se produjo un error", "Advertencia");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
         }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            frmStock s= new frmStock();
            s.ShowDialog();
        }
        private void Actualizar()
        {
            dgvDetallePedido.DataSource = DetallePedido.Buscar(txtBuscar.Text);
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbPedido.SelectedIndex < 0)
            {
                MessageBox.Show("Escoja un número de venta primero");
            }
            else
            {
                MostrarDetallePedido();
            }
        }
    }
}
