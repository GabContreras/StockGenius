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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            OcultarSubMenu();
        }
         private void OcultarSubMenu()
        {
                panelEmpleadosSubMenu.Visible = false;
                panelPedidosubMenu.Visible = false;

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
            mostrarSubMenu(panelPedidosubMenu);
        }
        #region SubMenuPedidos
        private void btnDetallePedido_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new AdministrarPedido());
            //Agregar código para abrir los formularios deseados
            OcultarSubMenu();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new DetallePedido());
            //Agregar código para abrir los formularios deseados
            OcultarSubMenu();
        }
#endregion
        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            //Agregar código para abrir los formularios deseados
            mostrarSubMenu(panelEmpleadosSubMenu);

        }
        #region SubmenuEmpleados
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new AdministrarEmpleados());
            //Agregar código para abrir los formularios deseados
            OcultarSubMenu();
        }

        private void btnUsuarios_Click_1(object sender, EventArgs e)
        {

        }
        #endregion
        private void btnFactura_Click_1(object sender, EventArgs e)
        {
            openChildFormInPanel(new Factura());
            //Agregar código para abrir los formularios deseados
            OcultarSubMenu();
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
            openChildFormInPanel(new Proveedores());
            OcultarSubMenu();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Producto());
            OcultarSubMenu();

        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Cliente());
            OcultarSubMenu();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
