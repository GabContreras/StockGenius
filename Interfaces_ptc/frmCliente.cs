using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos;


namespace Interfaces_ptc
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtApellido_Empleado_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            MostrarClientes();
        }
        private void MostrarClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = Clientes.CargarClientes();

        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            txtNombre.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
            txtApellido.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
            txtDui.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
            txtTelefono.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
            txtDirección.Text = dgvClientes.CurrentRow.Cells[5].Value.ToString();
            numEdad.Text = dgvClientes.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Clientes p = new Clientes();
                p.Nombre = txtNombre.Text;
                p.Apellido = txtApellido.Text;
                p.Dui = txtDui.Text;
                p.Telefono = txtTelefono.Text;
                p.Direccion = txtDirección.Text;
                p.Edad= int.Parse(numEdad.Text);
                if (p.insertarCiente() == true)
                {
                    MessageBox.Show("Cliente agregado satisfactoriamente", "Éxito");
                    MostrarClientes();
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
            MostrarClientes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dgvClientes.CurrentRow.Cells[0].Value.ToString());
                Clientes p = new Clientes();
                if (p.EliminarCliente(id) == true)
                {
                    MessageBox.Show("Cliente eliminado satisfactoriamente", "Éxito");
                    MostrarClientes();
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
            MostrarClientes();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Clientes p = new Clientes();
                p.Nombre = txtNombre.Text;
                p.Apellido = txtApellido.Text;
                p.Dui = txtDui.Text;
                p.Telefono = txtTelefono.Text;
                p.Direccion = txtDirección.Text;
                p.Edad = int.Parse(numEdad.Text);
                p.Id_Cliente = (int)dgvClientes.CurrentRow.Cells[0].Value;
                if (p.ActualizarCliente() == true)
                {
                    MessageBox.Show("Cliente actualizado satisfactoriamente", "Éxito");
                    MostrarClientes();
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
            MostrarClientes();
        }
    }
}
