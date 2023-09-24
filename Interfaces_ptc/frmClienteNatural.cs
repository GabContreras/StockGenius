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
    public partial class frmClienteNatural : Form
    {
        public frmClienteNatural(Usuario u)
        {
            InitializeComponent();
            if (u.Id_Rol == 5)
            {
                btnEliminar.Visible = false;

            }
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
            Actualizar();
        }
        private void MostrarClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = ClienteNatural.CargarClientes();

        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtNombre.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                txtDui.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                txtTelefono.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                txtDirección.Text = dgvClientes.CurrentRow.Cells[5].Value.ToString();
                numEdad.Text = dgvClientes.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDui.Text = "";
            txtTelefono.Text = "";
            txtDirección.Text = "";
            numEdad.Value = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text == "" || txtApellido.Text == "" || txtDui.Text == "" || 
                    txtTelefono.Text == ""|| txtDirección.Text=="")
                {
                    MessageBox.Show("No dejar campos vacíos",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ClienteNatural p = new ClienteNatural();
                    p.Nombre = txtNombre.Text;
                    p.Apellido = txtApellido.Text;
                    p.Dui = txtDui.Text;
                    p.Telefono = txtTelefono.Text;
                    p.Direccion = txtDirección.Text;
                    p.Edad = int.Parse(numEdad.Text);
                    p.Tipo_cliente = "Natural";
                    if (p.insertarCiente() == true)
                    {
                        MessageBox.Show("Cliente agregado satisfactoriamente", "Éxito");
                        MostrarClientes();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Se produjo un error", "Advertencia");
                    }
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
                ClienteNatural p = new ClienteNatural();
                if (p.EliminarCliente(id) == true)
                {
                    MessageBox.Show("Cliente inhabilitado satisfactoriamente", "Éxito");
                    MostrarClientes();
                    LimpiarCampos();
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
                if (txtNombre.Text == "" || txtApellido.Text == "" || txtDui.Text == "" ||
                  txtTelefono.Text == "" || txtDirección.Text == "")
                {
                    MessageBox.Show("No dejar campos vacíos",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else { 
                ClienteNatural p = new ClienteNatural();
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
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Se produjo un error", "Advertencia");
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MostrarClientes();
        }

        private void txtDui_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDui_KeyPress(object sender, KeyPressEventArgs e)
        {            
                // Permite números (0-9) y el guión (-)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
                {
                  MessageBox.Show("Solo números y guión son permitidos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   e.Handled = true; // Suprime el carácter
                }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números (0-9), guiones (-), un símbolo de más (+) y espacios.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '+' && e.KeyChar != ' ')
            {
                MessageBox.Show("Solo números, '-', '+', son permitidos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // Suprime el carácter
            }

            // Verificar si se ha ingresado más de un símbolo de más (+).
            if (e.KeyChar == '+' && (sender as TextBox).Text.Contains("+"))
            {
                MessageBox.Show("Solo se permite un símbolo +", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // Suprime el carácter
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo letras y espacios en blanco
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Solo letras son permitidas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // Suprime el carácter
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo letras y espacios en blanco
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Solo letras son permitidas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // Suprime el carácter
            }
        }
        private void Actualizar()
        {
            dgvClientes.DataSource = ClienteNatural.Buscar(txtBuscar.Text);            
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }
    }
}
