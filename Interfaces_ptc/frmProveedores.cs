using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos;

namespace Interfaces_ptc
{
    public partial class frmProveedores : Form
    {
        public frmProveedores(Usuario u)
        {
            InitializeComponent();

            if (u.Id_Rol == 2)
            {
                btnEliminar.Visible = false;

            }
        }
        private void Actualizar()
        {
            dgvProveedores.DataSource = Proveedores.Buscar(txtBuscar.Text);
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }
        private void MostrarProveedores()
        {
            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = Proveedores.CargarProveedores();
            dgvProveedores.Columns[0].Visible = false;
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }
        private void frmProveedores_Load(object sender, EventArgs e)
        {
            MostrarProveedores();
            Actualizar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text == "" || txtDireccion.Text == "" || txtTelefono.Text == "")
                {
                    MessageBox.Show("No dejar campos vacios",
                   "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Proveedores p = new Proveedores();
                    p.Nombre = txtNombre.Text;
                    p.Direccion = txtDireccion.Text;
                    p.Telefono = txtTelefono.Text;

                    if (p.InsertarProovedores() == true)
                    {
                        MessageBox.Show("Proovedor agregado satisfactoriamente", "Éxito");
                        MostrarProveedores();
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
            MostrarProveedores();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dgvProveedores.CurrentRow.Cells[0].Value.ToString());
                Proveedores p = new Proveedores();
                if (p.EliminarProveedores(id) == true)
                {
                    MessageBox.Show("Proveedor eliminado satisfactoriamente", "Éxito");
                    MostrarProveedores();
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
            MostrarProveedores();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {

                Proveedores p = new Proveedores();
                p.Nombre = txtNombre.Text;
                p.Direccion = txtDireccion.Text;
                p.Telefono = txtTelefono.Text;
                p.Id_Proveedor = (int)dgvProveedores.CurrentRow.Cells[0].Value;
                if (p.ActualizarProveedores() == true)
                {
                    MessageBox.Show("Proveedor actualizado satisfactoriamente", "Éxito");
                    MostrarProveedores();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Se produjo un error", "Advertencia");
                }
                MostrarProveedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MostrarProveedores();
        }

        private void dgvProveedores_DoubleClick(object sender, EventArgs e)
        {
            txtNombre.Text = dgvProveedores.CurrentRow.Cells[1].Value.ToString();
            txtDireccion.Text = dgvProveedores.CurrentRow.Cells[2].Value.ToString();
            txtTelefono.Text = dgvProveedores.CurrentRow.Cells[3].Value.ToString();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }
    }
}
