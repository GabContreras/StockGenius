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
            if (u.Id_Rol == 2)
            {
                btnClienteJuridico.Visible = false;
                btnClienteNatural.Visible = false;
                btnVentas.Visible = false;
                btnEmpleado.Visible = false;
                btnAgregarProductos.Visible = false;    
            }
            if (u.Id_Rol == 3)
            {
                btnClienteJuridico.Visible = false;
                btnClienteNatural.Visible = false;
                btnVentas.Visible = false;
                btnEmpleado.Visible = false;
                btnAgregarProductos.Visible = false;
            }
            else if (u.Id_Rol == 4)
            {
                btnClienteJuridico.Visible = false;
                btnClienteNatural.Visible = false;
                btnVentas.Visible = false;
                btnEmpleado.Visible = false;
                btnProveedores.Visible = false;
                btnAdministrarProductos.Visible = false;
            }
            else if (u.Id_Rol == 5)
            {
                btnProveedores.Visible = false;
                btnProducto.Visible = false;
                btnEmpleado.Visible = false;
                btnGenerarReporte.Visible = false;
            }

        }
           
    
        private void OcultarSubMenu()
        {                
            panelVentasubMenu.Visible = false;
            panelProductossubMenu.Visible = false;
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
            openChildFormInPanel(new frmPedido(v));
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
            openChildFormInPanel(new frmProveedores(v));
            OcultarSubMenu();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {

        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new frmClienteNatural(v));
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
            openChildFormInPanel(new frmClienteJuridico(v));
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

        private void btnEmpleado_Click_1(object sender, EventArgs e)
        {
         
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            frmCuenta c = new frmCuenta(v);
            c.ShowDialog();
        }

        private void btnAdministrarProductos_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new frmProducto(v));
            OcultarSubMenu();
        }

        private void btnProducto_Click_1(object sender, EventArgs e)
        {
            mostrarSubMenu(panelProductossubMenu);
        }

        private void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new frmAgregarProductos(v));
            OcultarSubMenu();
        }

        private void btnEmpleado_Click_2(object sender, EventArgs e)
        {
            openChildFormInPanel(new frmEmpleados(v));
            OcultarSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEscogeFecha EF= new frmEscogeFecha(v);
            EF.ShowDialog();
            OcultarSubMenu();
        }

        private void frmmenu_Load(object sender, EventArgs e)
        {

        }

        private void btnMicuenta_Click(object sender, EventArgs e)
        {
            frmMiPerfil Mpf = new frmMiPerfil(v);
            Mpf.ShowDialog();
        }
    }
}
