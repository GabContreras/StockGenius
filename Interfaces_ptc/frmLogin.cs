using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interfaces_ptc
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

        }

        private void btnMouseEnter(object sender, EventArgs e)
        {
            
        }
        private void btnMouseLeave(object sender, EventArgs e)
        {
           
        }
        private void txtEnter(object sender, EventArgs e)
        {
            

        }
        private void txtLeave(object sender, EventArgs e)
        {
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
         

        }

        private void panelRegistro_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Encrypt encr = new Encrypt();

            Usuario u = new Usuario();
            u.NombreUsuario= txtUser.Text;
            u.Contraseña= encr.Encriptar(txtPassword.Text);
            try
            {
                u = u.IniciarSesion();

                if(u==null)
                {
                    MessageBox.Show("Credenciales inválidas");
                }
                else 
                {
                    frmMenu menú = new frmMenu(u);
                    menú.Show();

                    menú.FormClosed += delegate
                    {
                        this.Show();
                    };

                    this.Hide();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }

        private void panelInicio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
        }

        private void btnAcceder_Click_1(object sender, EventArgs e)
        {
        
        }
          private void panelContraI_Paint(object sender, PaintEventArgs e)
          {

          }

        private void btnAcceder_Click_2(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void cbMostraContraInicio_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMostraContraInicio.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnsalir2_Click(object sender, EventArgs e)
        {
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
