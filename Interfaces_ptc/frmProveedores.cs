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
        public frmProveedores()
        {
            InitializeComponent();
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

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            MostrarProveedores();
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
    }
}
