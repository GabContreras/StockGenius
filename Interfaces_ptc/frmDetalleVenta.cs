using Modelos;
using System;
using System.Windows.Forms;

namespace Interfaces_ptc
{
    public partial class frmDetalleVenta : Form
    {
        public frmDetalleVenta()
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
            Mostrarproductos();
            cbPedido.SelectedIndex = -1;
            ActualizarProducto();
        }
        private void MostrarDetallePedido(int Id_pedido)
        {
            //Se carga el DGV en base al ID de venta seleccionado
            dgvDetallePedido.DataSource = null;

            DetallePedido dp = new DetallePedido();
            dp.Id_pedido = Id_pedido;

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
                cbPedido.DisplayMember = "Número de pedido";
                cbPedido.ValueMember = "Número de pedido";
            }

            //Bloque de código por si da error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Mostrarproductos()
        {
            //Manejo de excepciones 
            //El código que puede dar error
            try
            {
               dgvDetallePedido.DataSource = null;
        
                dgvProducto.DataSource = Producto.CargarProductoEnDetallePedido();

                dgvProducto.Columns[0].Visible = false;
            }

            //Bloque de código por si da error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDetallePedido_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                cbPedido.Text = dgvDetallePedido.CurrentRow.Cells[1].Value.ToString();
                txtCantidad.Text = dgvDetallePedido.CurrentRow.Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LimpiarCampo()
        {
            txtCantidad.Text = "";
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                MostrarDetallePedido((int)cbPedido.SelectedValue);

                int pedidoId = (int)cbPedido.SelectedValue;
                Pedido pd = new Pedido();
                // Obtener el estado del pedido
                string estadoPedido = pd.ObtenerEstadoPedido(pedidoId);

                if (estadoPedido.Equals("Completado"))
                {
                    MessageBox.Show("No se pueden agregar productos a un pedido completado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; // No continuar la ejecución del código
                }
                else if (estadoPedido.Equals("Anulado"))
                {
                    MessageBox.Show("No se pueden agregar productos a un pedido anulado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; // No continuar la ejecución del código
                }

                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("No dejar campos vacíos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cbPedido.SelectedIndex < 0)
                {
                    MessageBox.Show("Escoja un número de pedido primero");
                }
                else if (dgvProducto.SelectedRows.Count < 0)
                {
                    MessageBox.Show("Escoja un producto primero");
                }
                else
                {
                    DetallePedido p = new DetallePedido();
                    Producto pp = new Producto();

                    p.Id_pedido = pedidoId;
                    p.Id_Producto = (int)dgvProducto.CurrentRow.Cells[0].Value; ;
                    p.Cantidad = int.Parse(txtCantidad.Text);

                    // Se obtiene la cantidad en stock actual
                    int stockActual = pp.ObtenerStockProducto(p.Id_Producto);

                    if (stockActual >= p.Cantidad) // Se verifica si la cantidad excede el stock
                    {
                        if (p.InsertarDpedido() == true)
                        {
                            MessageBox.Show("Producto agregado satisfactoriamente", "Éxito");
                            LimpiarCampo();

                            // Después de insertar el detalle, recargamos los detalles del pedido
                            MostrarDetallePedido(pedidoId);
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
                MostrarDetallePedido((int)cbPedido.SelectedValue);

                int pedidoId = (int)cbPedido.SelectedValue;

                Pedido pd = new Pedido();
                // Obtener el estado del pedido
                string estadoPedido = pd.ObtenerEstadoPedido(pedidoId);

                if (estadoPedido.Equals("Completado"))
                {
                    MessageBox.Show("No se pueden agregar productos a un pedido completado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; // No continuar la ejecución del código
                }
                else if (estadoPedido.Equals("Anulado"))
                {
                    MessageBox.Show("No se pueden agregar productos a un pedido anulado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; // No continuar la ejecución del código
                }
                        
                        DetallePedido p = new DetallePedido();
                        if (p.EliminarDetallePedido(pedidoId) == true)
                        {
                            MessageBox.Show("Producto eliminado satisfactoriamente", "Éxito");
                            MostrarDetallePedido((int)cbPedido.SelectedValue);
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
            frmStock s = new frmStock();
            s.ShowDialog();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cbPedido.SelectedIndex < 0)
            {
                MessageBox.Show("Escoja un número de venta primero");
            }
            else
            {
                MostrarDetallePedido((int)cbPedido.SelectedValue);
            }
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            if (cbPedido.SelectedIndex < 0)
            {
                MessageBox.Show("Escoja un número de venta primero");
            }
            else
            {
                int pedidoId = (int)cbPedido.SelectedValue;
                Pedido pd = new Pedido();
                // Obtener el estado del pedido
                string estadoPedido = pd.ObtenerEstadoPedido(pedidoId);

                if (estadoPedido.Equals("Anulado"))
                {
                    MessageBox.Show("No se puede generar una factura para un pedido anulado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // No continuar la ejecución del código
                }
                else
                {
                    DetallePedido dp = new DetallePedido();
                    bool existencias = dp.ExisteDetallePedido(pedidoId);

                    if (!existencias)
                    {
                        MessageBox.Show("No se puede generar una factura si no hay productos ligados al pedido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // No continuar la ejecución del código
                    }
                    else
                    {
                        frmFactura ff = new frmFactura(pedidoId);
                        ff.ShowDialog();

                        Pedido p = new Pedido();
                        p.Id_Pedido = (int)cbPedido.SelectedValue;
                        p.Estado = "Completado";
                        p.ActualizarEstadoAlgenerarFactura();
                    }
                }
            }

        }

        private void cbPedido_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void dgvDetallePedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ActualizarProducto()
        {
            dgvProducto.DataSource = Producto.BuscarEnDetallePedido(txtBuscarProducto.Text);
            dgvProducto.Columns[0].Visible = false;
        }
        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            ActualizarProducto();
        }
    }
}
