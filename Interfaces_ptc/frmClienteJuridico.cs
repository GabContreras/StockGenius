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
        public frmClienteJuridico()
        {
            InitializeComponent();
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {

        }

        private void frmClienteJuridico_Load(object sender, EventArgs e)
        {
            MostrarClientes();
        }
        private void MostrarClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = ClienteJuridico.CargarClientes();

            dgvClientes.Columns[2].Visible = false;
            dgvClientes.Columns[3].Visible = false;
            dgvClientes.Columns[4].Visible = false;


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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MostrarClientes();
        }
    }
}
