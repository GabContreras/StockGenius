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

        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            MostrarProveedores();
        }
    }
}
