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
        public frmPedido()
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

        private void frmPedido_Load(object sender, EventArgs e)
        {
            CargarClien();
            CargarEmple();
            MostrarPedido();
        }
        private void MostrarPedido()
        {
            dgvPedido.DataSource = null;
            dgvPedido.DataSource = Pedido.CargarPedido();

        }

        private void dgvPedido_DoubleClick(object sender, EventArgs e)
        {
            cbCliente.Text = dgvPedido.CurrentRow.Cells[1].Value.ToString();
            cbEmpleado.Text = dgvPedido.CurrentRow.Cells[2].Value.ToString();
            dtpFecha.Text = dgvPedido.CurrentRow.Cells[3].Value.ToString();
        }
        private void CargarClien()
        {
            //Manejo de excepciones 
            //El código que puede dar error
            try
            {
                cbCliente.DataSource = null;
                cbCliente.DataSource = Clientes.CargarClientes();

                //El valor que se muestra en el combobox
                //Se coloca el nombre de la columna en la tabla
                cbCliente.DisplayMember = "Nombre";

                //Valor que no se muestra (id)
                //Se coloca el nombre de la columna en la tabla
                cbCliente.ValueMember = "Id_Cliente";
            }

            //Bloque de código por si da error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CargarEmple()
        {
            //Manejo de excepciones 
            //El código que puede dar error
            try
            {
                cbEmpleado.DataSource = null;
                cbEmpleado.DataSource = Empleados.CargarEmpleados();

                //El valor que se muestra en el combobox
                //Se coloca el nombre de la columna en la tabla
                cbEmpleado.DisplayMember = "Nombre";

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
            Pedido p = new Pedido();
            p.Id_Cliente = (int)cbCliente.SelectedValue;
            p.Id_Empleado = (int)cbEmpleado.SelectedValue;
            p.Fecha_Pedido = dtpFecha.Value; 

            if (p.InsertarPedido() == true)
            {
                MessageBox.Show("Pedido agregado satisfactoriamente", "Éxito");
                MostrarPedido();
            }
            else
            {
                MessageBox.Show("Se produjo un error al agregar el pedido", "Advertencia");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvPedido.CurrentRow.Cells[0].Value.ToString());
            Pedido p = new Pedido();
            if (p.EliminarPedido(id) == true)
            {
                MessageBox.Show("Pedido eliminado satisfactoriamente", "Éxito");
                MostrarPedido();
            }
            else
            {
                MessageBox.Show("Se produjo un error al eliminar el pedido", "Advertencia");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Pedido p = new Pedido();
            p.Id_Pedido = (int)dgvPedido.CurrentRow.Cells[0].Value;
            p.Id_Cliente = (int)cbCliente.SelectedValue;
            p.Id_Empleado = (int)cbEmpleado.SelectedValue;
            p.Fecha_Pedido = dtpFecha.Value;
            if (p.ActualizarPedido() == true)
            {
                MessageBox.Show("Pedido actualizado satisfactoriamente", "Éxito");
                MostrarPedido();
            }
            else
            {
                MessageBox.Show("Se produjo un error", "Advertencia");
            }
            MostrarPedido();
        }
    }
}
