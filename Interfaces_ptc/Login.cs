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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnMouseEnter(object sender, EventArgs e)
        {
            System.Windows.Forms.Button bt = sender as System.Windows.Forms.Button;
            foreach (Control ctr in panelPrincipal.Controls) 
            {
                if(ctr is System.Windows.Forms.Button)
                {
                    bt.ForeColor= Color.Black;
                }
            }
        }
        private void btnMouseLeave(object sender, EventArgs e)
        {
            System.Windows.Forms.Button bt = sender as System.Windows.Forms.Button;
            foreach (Control ctr in panelPrincipal.Controls) 
            {
                if (ctr is System.Windows.Forms.Button)
                {
                    bt.ForeColor = Color.White;
                }
            }
        }
        private void txtEnter(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tx = sender as System.Windows.Forms.TextBox;
            foreach(Control ctr in panelRegistro.Controls)
            {
                if(ctr is Panel && ctr.Name == "p" + tx.Tag.ToString())
                {
                    ctr.BackColor = Color.Black;
                }
            }

        }
        private void txtLeave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tx = sender as System.Windows.Forms.TextBox;
            foreach (Control ctr in panelRegistro.Controls)
            {
                if (ctr is Panel && ctr.Name == "p" + tx.Tag.ToString())
                {
                    ctr.BackColor = Color.Silver;
                }
            }

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
            menu menú = new menu();
            menú.Show();
           
            menú.FormClosed += delegate
            {
                this.Show();
            };

            this.Hide();
        }

        private bool controlTimer = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!controlTimer)
            {
                panelContenedor.Left += 10;
                panelRegistro.BringToFront();
                if (panelContenedor.Left == 400)
                {
                    timer1.Stop();
                    controlTimer = true;
                }
            }
            else
            {
                panelContenedor.Left -= 10;
                panelInicio.BringToFront();
                if (panelContenedor.Left == 0)
                {
                    timer1.Stop();
                    controlTimer = false;
                }
            }
        }

        private void panelInicio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            timer1.Start(); 
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
            timer1.Start();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMostrarContraReg.Checked)
            {
                txtContra.UseSystemPasswordChar = false;
            }
            else
            {
                txtContra.UseSystemPasswordChar = true;
            }
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
    }
}
