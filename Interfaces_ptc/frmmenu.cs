using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Modelos;
using System.Diagnostics.Contracts;

namespace Interfaces_ptc
{
    public partial class frmmenu : Form
    {
        Usuario v;
        public frmmenu(Usuario u)
        {
            InitializeComponent();
            OcultarSubMenu();

            v = u;             
             if(u.Id_Rol == 3)
              {
                btnEmpleado.Visible = false;
                btnProveedores.Visible= false; 
                btnProducto.Visible= false;
            }
            else if(u.Id_Rol==4)
            {
                btnProveedores.Visible = false;
                btnProducto.Visible = false;
                btnCliente.Visible= false;
                btnVentas.Visible = false;
            }
            else if(u.Id_Rol==5)
            {
                btnCliente.Visible = false;
                btnEmpleado.Visible = false;
                btnVentas.Visible = false;
            }


        }
           
    
        private void OcultarSubMenu()
         {                
            panelVentasubMenu.Visible = false;
         }
        private void mostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                OcultarSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelVentasubMenu);
        }
        #region SubMenuPedidos
        private void btnDetallePedido_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new frmPedido());
            //Agregar código para abrir los formularios deseados
            OcultarSubMenu();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new frmDetallePedido());
            //Agregar código para abrir los formularios deseados
            OcultarSubMenu();
        }
#endregion
        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            

        }
        #region SubmenuEmpleados
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            openChildFormInPanel(new frmEmpleados(u));
            //Agregar código para abrir los formularios deseados
            OcultarSubMenu();
        }

        private void btnUsuarios_Click_1(object sender, EventArgs e)
        {

        }
        #endregion
        private void btnFactura_Click_1(object sender, EventArgs e)
        {
         
        }
        private Form activeForm = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(childForm);
            panelContenedor.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new frmProveedores());
            OcultarSubMenu();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new frmProducto());
            OcultarSubMenu();

        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new frmCliente());
            OcultarSubMenu();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdministrarEmpleados_Click(object sender, EventArgs e)
        {
            
            openChildFormInPanel(new frmEmpleados(v));
            OcultarSubMenu();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {         
           
           

        }


        private void frmmenu_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.Show();
            this.Hide();
        }
       
        private void frmmenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
