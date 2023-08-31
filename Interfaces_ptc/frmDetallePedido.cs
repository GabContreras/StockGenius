using Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            CargarPed();
            cargarProd();
            MostrarDetallePedido();
        }
        private void MostrarDetallePedido()
        {
            dgvDetallePedido.DataSource = null;
            dgvDetallePedido.DataSource = DetallePedido.CargarDetallePedido();
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
                cbProducto.DisplayMember = "Nombre_Producto";

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCantidad.Text == "" )
                {
                    MessageBox.Show("No dejar campos vacios",
                   "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DetallePedido p = new DetallePedido();
                    p.Id_pedido = int.Parse(cbPedido.Text);
                    p.Id_Producto = (int)cbProducto.SelectedValue;
                    p.Cantidad = int.Parse(txtCantidad.Text);
                    p.Total = ((int.Parse(txtCantidad.Text)) * ObtenerPrecioProducto(p.Id_Producto));
                    // Se obtiene la cantidad en stock actual
                    int stockActual = ObtenerStockProducto(p.Id_Producto);

                    if (stockActual >= p.Cantidad) // Se verifica si la cantidad excede el stock
                    {
                        if (p.InsertarDpedido() == true)
                        {
                            MessageBox.Show("Detalle agregado satisfactoriamente", "Éxito");
                            MostrarDetallePedido();
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
        private int ObtenerStockProducto(int idProducto)
        {

            // se agrega la consulta para sabe cuanto hay en stock
            int stock = 0;
            SqlConnection con = Conexion.Conectar();
            string query = "SELECT Stock FROM Producto WHERE Id_Producto = @Id_Producto";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id_Producto", idProducto);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    stock = Convert.ToInt32(reader["Stock"]);
                }
            }

            return stock;
        }

        private int ObtenerPrecioProducto(int idProducto)
        {

            // se agrega la consulta para sabe cuanto hay en stock
            int PrecioUnitario = 0;
            SqlConnection con = Conexion.Conectar();
            string query = "SELECT PrecioUnitario FROM Producto WHERE Id_Producto = @Id_Producto";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id_Producto", idProducto);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    PrecioUnitario = Convert.ToInt32(reader["PrecioUnitario"]);
                }
            }

            return PrecioUnitario;
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
    }
}
