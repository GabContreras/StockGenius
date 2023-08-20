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
    public partial class frmCargo : Form
    {
        public frmCargo()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MostrarCargos()
        {
            dgvCargo.DataSource = null;
            dgvCargo.DataSource = Cargo.CargarCargos();

        }

        private void frmCargo_Load(object sender, EventArgs e)
        {
            MostrarCargos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cargo c = new Cargo();
            c.Nombre = txtNombre.Text;
         
            if (c.InsertarCargos() == true)
            {
                MessageBox.Show("Cargo agregado satisfactoriamente", "Éxito");
                MostrarCargos();
            }
            else
            {
                MessageBox.Show("Se produjo un error", "Advertencia");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvCargo.CurrentRow.Cells[0].Value.ToString());
            Cargo c = new Cargo();
            if (c.EliminarCargos(id) == true)
            {
                MessageBox.Show("Cargo eliminado satisfactoriamente", "Éxito");
                MostrarCargos();
            }
            else
            {
                MessageBox.Show("Se produjo un error", "Advertencia");
            }
        }

        private void dgvCargo_DoubleClick(object sender, EventArgs e)
        {
            txtNombre.Text = dgvCargo.CurrentRow.Cells[1].Value.ToString();

        }
    }
}
