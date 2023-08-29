using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interfaces_ptc
{
    public partial class frmEmpleados : Form
    {
        public frmEmpleados(Usuario u)
        {
            InitializeComponent();


                //btnEliminar.Visible = false;
        
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarRol()
        {
            //Manejo de excepciones 
            //El código que puede dar error
            try
            {
                cbRol.DataSource = null;
                cbRol.DataSource = Roles.CargarRoles();

                //El valor que se muestra en el combobox
                //Se coloca el nombre de la columna en la tabla
                cbRol.DisplayMember = "Rol";

                //Valor que no se muestra (id)
                //Se coloca el nombre de la columna en la tabla
                cbRol.ValueMember = "Id_Rol";
            }

            //Bloque de código por si da error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            CargarRol();
            MostrarEmpleados();
        }
        private void MostrarEmpleados()
        {
            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = Empleados.CargarEmpleados();

        }

        private void cbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbRol.DataSource= dgvEmpleados.CurrentRow.Cells[1].Value;

        }

        private void btnNewCat_Click(object sender, EventArgs e)
        {
            
        }

        private void frmEmpleados_DoubleClick(object sender, EventArgs e)
        {
           

        }
        //Agregar doubleclick cuando esté corregido
        private void dgvEmpleados_DoubleClick(object sender, EventArgs e)
        {

            txtNombreUsuario.Text = dgvEmpleados.CurrentRow.Cells[3].Value.ToString();
            txtContraseña.Text = dgvEmpleados.CurrentRow.Cells[4].Value.ToString();
            cbRol.Text = dgvEmpleados.CurrentRow.Cells[2].Value.ToString();
            txtCargo.Text= dgvEmpleados.CurrentRow.Cells[5].Value.ToString();
            txtNombre.Text = dgvEmpleados.CurrentRow.Cells[6].Value.ToString();
            txtApellido.Text = dgvEmpleados.CurrentRow.Cells[7].Value.ToString();
            txtTelefono.Text = dgvEmpleados.CurrentRow.Cells[8].Value.ToString();
            txtDui.Text = dgvEmpleados.CurrentRow.Cells[9].Value.ToString();
            txtCorreo.Text = dgvEmpleados.CurrentRow.Cells[10].Value.ToString();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Usuario U = new Usuario();
            U.NombreUsuario= txtNombreUsuario.Text; 
            U.Contraseña = txtContraseña.Text;
            U.Id_Rol = (int)cbRol.SelectedValue;
              
            Empleados E = new Empleados();
            E.Nombre_Empleado = txtNombre.Text;
            E.Apellido = txtApellido.Text;
            E.Telefono = txtTelefono.Text;
            E.Dui = txtDui.Text;
            E.Correo = txtCorreo.Text;
            E.Cargo = txtCargo.Text;
           
                if (U.InsertarUsuario() == true)
                {
                    if (E.InsertarEmpleado() == true)
                    {
                        MessageBox.Show("Producto agregado satisfactoriamente", "Éxito");
                        MostrarEmpleados();
                    }
                    else
                    {
                        MessageBox.Show("Se produjo un error", "Advertencia");
                    }
                }
           
            MostrarEmpleados();
        }

        private void frmEmpleados_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
