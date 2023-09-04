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
    public partial class frmClienteJuridico : Form
    {
        public frmClienteJuridico(Usuario u)
        {
            InitializeComponent();
            if (u.Id_Rol == 5)
            {
                btnEliminar.Visible = false;

            }
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtNombreEmpresa.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                txtNIT.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                txtNRC.Text = dgvClientes.CurrentRow.Cells[5].Value.ToString();
                txtGiro.Text = dgvClientes.CurrentRow.Cells[6].Value.ToString();
                cbCategoria.Text = dgvClientes.CurrentRow.Cells[7].Value.ToString();
                txtDireccion.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                txtTelefono.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LimpiarCampos()
        {
            txtNombreEmpresa.Text = "";
            txtNIT.Text = "";
            txtNRC.Text = "";
            txtGiro.Text = "";
            cbCategoria.SelectedIndex = -1;
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }
        private void frmClienteJuridico_Load(object sender, EventArgs e)
        {
            MostrarClientes();
            Actualizar();

        }
        private void MostrarClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = ClienteJuridico.CargarClientes();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreEmpresa.Text == "" || txtNIT.Text == "" || txtNRC.Text == "" ||
                    txtGiro.Text == "" || txtDireccion.Text == "" || txtTelefono.Text == "")
                {
                    MessageBox.Show("No dejar campos vacíos",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!txtNRC.Text.Contains("-"))
                {
                    MessageBox.Show("El campo NRC debe contener un guión (-)",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Resto del código para procesar los datos.
                    ClienteJuridico p = new ClienteJuridico();
                    p.NombreEmpresa = txtNombreEmpresa.Text;
                    p.NIT = txtNIT.Text;
                    p.NRC = txtNRC.Text;
                    p.Giro = txtGiro.Text;
                    p.Categoria = cbCategoria.Text;
                    p.Direccion = txtDireccion.Text;
                    p.Telefono = txtTelefono.Text;
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
                ClienteJuridico p = new ClienteJuridico();
                if (p.EliminarCliente(id) == true)
                {
                    MessageBox.Show("Cliente eliminado satisfactoriamente", "Éxito");
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
                if (txtNombreEmpresa.Text == "" || txtNIT.Text == "" || txtNRC.Text == "" ||
                    txtGiro.Text == "" || txtDireccion.Text == "" || txtTelefono.Text == "")
                {
                    MessageBox.Show("No dejar campos vacíos",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!txtNRC.Text.Contains("-"))
                {
                    MessageBox.Show("El campo NRC debe contener un guión (-)",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ClienteJuridico p = new ClienteJuridico();
                    p.NombreEmpresa = txtNombreEmpresa.Text;
                    p.NIT = txtNIT.Text;
                    p.NRC = txtNRC.Text;
                    p.Giro = txtGiro.Text;
                    p.Categoria = cbCategoria.Text;
                    p.Direccion = txtDireccion.Text;
                    p.Telefono = txtTelefono.Text;
                    p.Id_cliente = (int)dgvClientes.CurrentRow.Cells[0].Value;
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

        private void txtNRC_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números (0-9) y el guión (-).
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                MessageBox.Show("Solo números y '-' son permitidos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // Suprime el carácter
               
            }

            // Verificar si el guión se agrega al principio.
            if (e.KeyChar == '-' && (sender as TextBox).Text.Length == 0)
            {
                e.Handled = true;
                MessageBox.Show("No se puede agregar un guion al principio del NRC.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // Suprime el carácter
            }


            // Asegurarse de que solo haya un guion (-).
            if (e.KeyChar == '-' && (sender as TextBox).Text.IndexOf('-') >= 0)
            {
                MessageBox.Show("Solo debe haber un guion", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // Suprime el carácter
               
            }
        }

        private void txtGiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacios en blanco y comas.
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != ',')
            {
                MessageBox.Show("Solo letras, espacios y comas son permitidas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        private void Actualizar()
        {
            dgvClientes.DataSource = ClienteJuridico.Buscar(txtBuscar.Text);
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
