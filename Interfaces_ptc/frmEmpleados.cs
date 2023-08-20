using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interfaces_ptc
{
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            MostrarEmpleados();
        }
        private void MostrarEmpleados()
        {
            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = Empleados.CargarEmpleados();

        }

        private void cbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCargo.DataSource= dgvEmpleados.CurrentRow.Cells[1].Value;

        }

        private void btnNewCat_Click(object sender, EventArgs e)
        {
            frmCargo cat = new frmCargo();
            cat.ShowDialog();
        }

        private void frmEmpleados_DoubleClick(object sender, EventArgs e)
        {
           

        }

        private void dgvEmpleados_DoubleClick(object sender, EventArgs e)
        {
            txtNombreUsuario.Text = dgvEmpleados.CurrentRow.Cells[2].Value.ToString();
            txtContraseña.Text = dgvEmpleados.CurrentRow.Cells[3].Value.ToString();
            cbCargo.Text = dgvEmpleados.CurrentRow.Cells[9].Value.ToString();
            txtNombre.Text = dgvEmpleados.CurrentRow.Cells[4].Value.ToString();
            txtApellido.Text = dgvEmpleados.CurrentRow.Cells[5].Value.ToString();
            txtTelefono.Text = dgvEmpleados.CurrentRow.Cells[6].Value.ToString();
            txtDui.Text = dgvEmpleados.CurrentRow.Cells[7].Value.ToString();
            txtCorreo.Text = dgvEmpleados.CurrentRow.Cells[8].Value.ToString();

        }
    }
}
