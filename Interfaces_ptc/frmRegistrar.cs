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
    public partial class frmRegistrar : Form
    {
        public frmRegistrar()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Encrypt encr = new Encrypt();

                Usuario U = new Usuario();
                U.NombreUsuario = txtNombreUsuario.Text;
                U.Contraseña = encr.Encriptar(txtContraseña.Text);
                U.Id_Rol = 2;
            
                if (U.InsertarUsuario() == true)
                {
                    Empleados E = new Empleados();
                    E.Nombre_Empleado = txtNombre.Text;
                    E.Apellido = txtApellido.Text;
                    E.Telefono = txtTelefono.Text;
                    E.Dui = txtDui.Text;
                    E.Correo = txtCorreo.Text;
                    E.Cargo = txtCargo.Text;
                    E.Id_Usuario = Usuario.ConseguirIdUsuario(txtNombreUsuario.Text);

                    if (E.InsertarEmpleado() == true)
                    {
                        MessageBox.Show("Usuario registrado satisfactoriamente, puede iniciar sesión", "Éxito");

                    }
                    else
                    {
                        MessageBox.Show("Se produjo un error al registrar el usuario", "Advertencia");
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
