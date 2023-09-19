﻿using Modelos;
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
            cbPedido.SelectedIndex = -1;
            cbProducto.SelectedIndex = -1;
        }
        private void MostrarDetallePedido(int Id_pedido)
        {
            //Se carga el DGV en base al ID de venta seleccionado
            dgvDetallePedido.DataSource = null;

            DetallePedido dp = new DetallePedido();
            dp.Id_pedido = Id_pedido;

            dgvDetallePedido.DataSource = dp.CargarDetallePedido();

            ////dgvDetallePedido.Columns[0].Visible = false;
            ////dgvDetallePedido.Columns[6].Visible = false;

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
                cbPedido.ValueMember = "Id_Pedido";
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
            try
            {
                cbPedido.Text = dgvDetallePedido.CurrentRow.Cells[1].Value.ToString();
                cbProducto.Text = dgvDetallePedido.CurrentRow.Cells[3].Value.ToString();
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
                // Cargar los detalles del pedido
                MostrarDetallePedido((int)cbPedido.SelectedValue);

              
                    // Obtener el estado del pedido desde el DataGridView
                    string estadoPedido = dgvDetallePedido.CurrentRow.Cells["Estado"].Value.ToString();

                    // Verificar si el estado del pedido es "Completado" o "Anulado"
                    if (estadoPedido.Equals("Completado"))
                    {
                        MessageBox.Show("No se pueden agregar productos a un pedido completado.", "Advertencia");
                        return; // No continuar la ejecución del código
                    }
                    else if (estadoPedido.Equals("Anulado"))
                    {
                        MessageBox.Show("No se pueden agregar productos a un pedido anulado.", "Advertencia");
                        return; // No continuar la ejecución del código
                    }
                
                else
                {
                    if (txtCantidad.Text == "")
                    {
                        MessageBox.Show("No dejar campos vacíos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                        p.Id_pedido = (int)cbPedido.SelectedValue;
                        p.Id_Producto = (int)cbProducto.SelectedValue;
                        p.Cantidad = int.Parse(txtCantidad.Text);
                        // Se obtiene la cantidad en stock actual
                        int stockActual = pp.ObtenerStockProducto(p.Id_Producto);

                        if (stockActual >= p.Cantidad) // Se verifica si la cantidad excede el stock
                        {
                            if (p.InsertarDpedido() == true)
                            {
                                MessageBox.Show("Detalle agregado satisfactoriamente", "Éxito");
                                LimpiarCampo();

                                // Después de insertar el detalle, recargamos los detalles del pedido
                                MostrarDetallePedido((int)cbPedido.SelectedValue);
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
                // Cargar los detalles del pedido
                MostrarDetallePedido((int)cbPedido.SelectedValue);

                if (dgvDetallePedido.Rows.Count > 0)
                {
                    // Obtener el estado del pedido desde el DataGridView
                    string estadoPedido = dgvDetallePedido.CurrentRow.Cells["Estado"].Value.ToString();
                    // Verificar si el estado del pedido es "Completado" o "Anulado"
                    if (estadoPedido.Equals("Completado"))
                    {
                        MessageBox.Show("No se pueden eliminar productos de un pedido completado.", "Advertencia");
                        return; // No continuar la ejecución del código
                    }
                    else if (estadoPedido.Equals("Anulado"))
                    {
                        MessageBox.Show("No se pueden eliminar productos de un pedido anulado.", "Advertencia");
                        return; // No continuar la ejecución del código
                    }
                }
                else
                {
                    if (dgvDetallePedido.CurrentRow != null)
                    {
                        int id = int.Parse(dgvDetallePedido.CurrentRow.Cells[0].Value.ToString());
                        DetallePedido p = new DetallePedido();
                        if (p.EliminarDetallePedido(id) == true)
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
                    else
                    {
                        MessageBox.Show("No hay una fila seleccionada en el DataGridView", "Advertencia");
                    }
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
                int id_pedido = (int)cbPedido.SelectedValue;
                frmFactura ff = new frmFactura(id_pedido);
                ff.ShowDialog();

                Pedido p = new Pedido();
                p.Id_Pedido = (int)cbPedido.SelectedValue;
                p.Estado = "Completado";
                p.ActualizarEstadoAlgenerarFactura();
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
    }
}
