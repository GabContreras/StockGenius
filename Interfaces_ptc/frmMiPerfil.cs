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

            txtId.Visible = false;
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
                txtId.Text = usuario.Id_usuario.ToString();
                // Otros campos que desees cargar

                // Puedes acceder a las propiedades de usuario y empleado según sea necesario
            }
            else
            {
                usuario = v.ObtenerInfoSoloUsuario();
                txtEmail.Text = "No tiene";
                txtNombre.Text= "Administrador Maestro";
                txtUsuario.Text = usuario.NombreUsuario;
                txtId.Text = usuario.Id_usuario.ToString();
            }
           }

        private void LimpiarCampo()
        {
            txtContraseña.Text = "";
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si la contraseña no está vacía y actualizar el usuario
                if (txtContraseña.Text == "")
                {
                    MessageBox.Show("No dejar campos vacíos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else { 
                    Encrypt encr = new Encrypt();
                    Usuario us = new Usuario();
                    us.Id_usuario = int.Parse(txtId.Text);
                    us.Contraseña = encr.Encriptar(txtContraseña.Text);
                    if (us.ActualizarContraseña() == true)
                    {
                        MessageBox.Show("Contraseña actualizada satisfactoriamente", "Éxito");
                        LimpiarCampo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
