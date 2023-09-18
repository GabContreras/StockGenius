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
        public frmPedido(Usuario u)
        {
            InitializeComponent();

            if (u.Id_Rol == 5)
            {
                btnEliminar.Visible = false;

            }

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
            CargarEmple();
            MostrarPedido();
            MostrarClientes(); 
            cbEmpleado.SelectedIndex = -1;
            ActualizarCliente();
            ActualizarPedido();
        }
        private void MostrarPedido()
        {
            dgvPedido.DataSource = null;
            dgvPedido.DataSource = Pedido.CargarPedido();
        }
        private void MostrarClientes()
        {
            dgvCliente.DataSource = null;
            dgvCliente.DataSource = ClienteNatural.CargarAmbosClientes();
            dgvCliente.Columns[0].Visible = false;
        }
        private void dgvPedido_DoubleClick(object sender, EventArgs e)
        {
          
        }
        private void CargarEmple()
        {
            //Manejo de excepciones 
            //El código que puede dar error
            try
            {
                cbEmpleado.DataSource = null;
                cbEmpleado.DataSource = Empleados.CargarEmpleados2();

                //El valor que se muestra en el combobox
                //Se coloca el nombre de la columna en la tabla
                cbEmpleado.DisplayMember = "Empleado";

                //Valor que no se muestra (id)
                //Se coloca el nombre de la columna en la tabla
                cbEmpleado.ValueMember = "Id_Empleado";
            }

            //Bloque de código por si da error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {   
                Pedido p = new Pedido();
                p.Id_Cliente = (int)dgvCliente.CurrentRow.Cells[0].Value;
                p.Id_Empleado = (int)cbEmpleado.SelectedValue;
                p.Fecha_Pedido = DateTime.Now;
                p.Estado = "En proceso";
                if (p.InsertarPedido() == true)
                {
                    MessageBox.Show("Pedido agregado satisfactoriamente", "Éxito");
                    MostrarPedido();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Se produjo un error al agregar el pedido", "Advertencia");
                }
                MostrarPedido();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 

        private void LimpiarCampos()
        {
            cbEmpleado.SelectedIndex = -1;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el estado del pedido desde el DataGridView
                string estadoPedido = dgvPedido.CurrentRow.Cells["Estado"].Value.ToString();

                // Verificar si el estado del pedido es "Completado" o "Anulado"
                if (estadoPedido.Equals("Completado"))
                {
                    MessageBox.Show("No se puede eliminar un pedido completado.", "Advertencia");
                }
                else if (estadoPedido.Equals("Anulado"))
                {
                    MessageBox.Show("No se puede eliminar un pedido anulado.", "Advertencia");
                }
                else
                {
                    int id = int.Parse(dgvPedido.CurrentRow.Cells[0].Value.ToString());
                    Pedido p = new Pedido();
                    if (p.EliminarPedido(id) == true)
                    {
                        MessageBox.Show("Pedido eliminado satisfactoriamente", "Éxito");
                        MostrarPedido();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Se produjo un error al eliminar el pedido", "Advertencia");
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
            try
            {
                // Obtener el estado del pedido desde el DataGridView
                string estadoPedido = dgvPedido.CurrentRow.Cells["Estado"].Value.ToString();

                // Verificar si el estado del pedido es "Completado" o "Anulado"
                if (estadoPedido.Equals("Completado"))
                {
                    MessageBox.Show("No se puede actualizar un pedido completado.", "Advertencia");
                }
                else if (estadoPedido.Equals("Anulado"))
                {
                    MessageBox.Show("No se puede actualizar un pedido anulado.", "Advertencia");
                }
                else
                {
                    Pedido p = new Pedido();
                    p.Id_Pedido = (int)dgvPedido.CurrentRow.Cells[0].Value;
                    p.Id_Cliente = (int)dgvCliente.CurrentRow.Cells[0].Value;
                    p.Id_Empleado = (int)cbEmpleado.SelectedValue;

                    if (p.ActualizarPedido() == true)
                    {
                        MessageBox.Show("Pedido actualizado satisfactoriamente", "Éxito");
                        MostrarPedido();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Se produjo un error", "Advertencia");
                    }
                    MostrarPedido();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ActualizarCliente()
        {
            dgvCliente.DataSource = ClienteNatural.Buscar2(txtBuscarCliente.Text);
            dgvCliente.Columns[0].Visible = false;
        }
        private void ActualizarPedido()
        {
            dgvPedido.DataSource = Pedido.Buscar(txtBuscar.Text);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ActualizarCliente();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ActualizarPedido();
        }
    }
}
