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
    public partial class frmCuenta : Form
    {
        Usuario v;
        public frmCuenta(Usuario u)
        {
            InitializeComponent();
            //Se le asigna la información del objeto "u" al objeto global "v" para que pueda usarse en todos los métodos
            v = u;

        }

        private void frmCuenta_Load(object sender, EventArgs e)
        {
            //Se crea un empleado al que se le asigna el usuario que inició sesión
            Usuario U = new Usuario();
            Empleados emp = new Empleados();
            U.NombreUsuario = v.NombreUsuario;

            //Se ejecuta el método ObtenerInfo() del objeto 'emp' y se asigna la información obtenida a él mismo.
            //Es decir que, inicialmente, contiene la información del usuario que inició sesión
            //Luego se verifica qué empleado corresponde a él y se le asigna dicha información a él mismo (nombre, correo, etc.)
            emp = emp.ObtenerInfo();

            txtEmail.Text = emp.Correo;
            txtNombre.Text = emp.Nombre_Empleado;
            txtUsuario.Text = U.NombreUsuario;

        }
    }
}
