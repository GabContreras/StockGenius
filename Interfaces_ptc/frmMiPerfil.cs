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
    public partial class frmMiPerfil : Form
    {
        Usuario v;
        public frmMiPerfil(Usuario u)
        {
            InitializeComponent();

            v = u;
        }

            private void frmMiPerfil_Load(object sender, EventArgs e)
            {
            // Crear instancias de Usuario y Empleado
            Usuario usuario = new Usuario();
            Empleado empleado = new Empleado();

            // Obtener información del usuario y empleado
            (usuario, empleado) = v.ObtenerInfo();

            // Verificar si se obtuvo información válida
            if (usuario != null && empleado != null)
            {
                txtEmail.Text = empleado.Correo;
                txtNombre.Text = empleado.Nombre;
                txtUsuario.Text = usuario.NombreUsuario;
                // Otros campos que desees cargar

                // Puedes acceder a las propiedades de usuario y empleado según sea necesario
            }
            else
            {
                MessageBox.Show("No se encontró información para este usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }
    }
}
