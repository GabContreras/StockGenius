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
    public partial class frmPrimerUso : Form
    {
        public frmPrimerUso()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txtNombreUsuario.Text == "" || txtContraseña.Text == "")
                {
                    MessageBox.Show("No dejar campos vacios",
                   "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Encrypt encr = new Encrypt();

                    Usuario us = new Usuario();
                    us.NombreUsuario = txtNombreUsuario.Text;
                    us.Contraseña = encr.Encriptar(txtContraseña.Text);
                    us.Id_Rol = 1;

                    us.InsertarUsuario();

                    MessageBox.Show("Se ha creado el usuario correctamente." +
                        "La aplicación se reiniciará para que surtan efecto los cambios.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.Restart();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }
        

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbMostrar_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbMostrar.Checked)
            {
                txtContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = true;
            }
        }
    }
}

