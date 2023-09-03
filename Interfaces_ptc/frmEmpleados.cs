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

          
           if (u.Id_Rol== 2)
           {
                btnEliminar.Visible = false;
                btnActualizar.Visible = false;
                btnAgregar.Visible = false;
           }
           if (u.Id_Rol == 3)
           {
              
           }
           else if (u.Id_Rol == 4)
           {
                
           }
           else if (u.Id_Rol == 5)
           {
               
           }
            

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
                cbRol.DisplayMember = "nombre";

                //Valor que no se muestra (id)
                //Se coloca el nombre de la columna en la tabla
                cbRol.ValueMember = "id";
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

            dgvEmpleados.Columns[0].Visible = false;
            dgvEmpleados.Columns[1].Visible = false;
            dgvEmpleados.Columns[2].Visible = false;
            dgvEmpleados.Columns[10].Visible = false;

        }

        private void cbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNewCat_Click(object sender, EventArgs e)
        {
            
        }

        private void frmEmpleados_DoubleClick(object sender, EventArgs e)
        {
           

        }
        private void dgvEmpleados_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Encrypt encr = new Encrypt();

                txtNombreUsuario.Text = dgvEmpleados.CurrentRow.Cells[9].Value.ToString();
                cbRol.Text = dgvEmpleados.CurrentRow.Cells[3].Value.ToString();
                txtCargo.Text = dgvEmpleados.CurrentRow.Cells[11].Value.ToString();
                txtNombre.Text = dgvEmpleados.CurrentRow.Cells[4].Value.ToString();
                txtApellido.Text = dgvEmpleados.CurrentRow.Cells[5].Value.ToString();
                txtTelefono.Text = dgvEmpleados.CurrentRow.Cells[6].Value.ToString();
                txtDui.Text = dgvEmpleados.CurrentRow.Cells[7].Value.ToString();
                txtCorreo.Text = dgvEmpleados.CurrentRow.Cells[8].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LimpiarCampos()
        {
            txtNombreUsuario.Text = "";
            txtContraseña.Text = "";
            txtCargo.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtDui.Text = "";
            txtCorreo.Text = "";
        }

            private void btnAgregar_Click(object sender, EventArgs e)
            {
            try
            {
                if (txtNombreUsuario.Text == "" || txtContraseña.Text == "" || txtCargo.Text == "" || txtNombre.Text == "" || txtApellido.Text == ""
                    || txtTelefono.Text == "" || txtDui.Text == "" || txtCorreo.Text == "")
                {
                    MessageBox.Show("No dejar campos vacíos",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Encrypt encr = new Encrypt();

                    Usuario U = new Usuario();
                    U.NombreUsuario = txtNombreUsuario.Text;
                    U.Contraseña = encr.Encriptar(txtContraseña.Text);
                    U.Id_Rol = (int)cbRol.SelectedValue;

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
                            MessageBox.Show("Empleado agregado satisfactoriamente", "Éxito");
                            MostrarEmpleados();
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("Se produjo un error al insertar el empleado", "Advertencia");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se produjo un error al insertar el usuario", "Advertencia");
                    }
                    MostrarEmpleados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MostrarEmpleados();
        }

        private void frmEmpleados_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dgvEmpleados.CurrentRow.Cells[0].Value.ToString());
                Empleados E = new Empleados();
                
                if (E.EliminarEmpleado(id) == true)
                {
                    
                    int idU = int.Parse(dgvEmpleados.CurrentRow.Cells[2].Value.ToString());
                    Usuario U = new Usuario();
                    if (U.EliminarUsuario(idU) == true)
                    {
                        MessageBox.Show("Empleado eliminado satisfactoriamente", "Éxito");
                        MostrarEmpleados();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Se produjo un error al eliminar el empleado", "Advertencia");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MostrarEmpleados();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreUsuario.Text == "" ||  txtCargo.Text == "" || txtNombre.Text == "" || txtApellido.Text == ""
                    || txtTelefono.Text == "" || txtDui.Text == "" || txtCorreo.Text == "")
                {
                    MessageBox.Show("No dejar campos vacíos",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Encrypt encr = new Encrypt();

                    Usuario U = new Usuario();
                    U.NombreUsuario = txtNombreUsuario.Text;
                    U.Contraseña = encr.Encriptar(txtContraseña.Text);
                    U.Id_Rol = (int)cbRol.SelectedValue;
                    U.Id_usuario = (int)dgvEmpleados.CurrentRow.Cells[2].Value;
                    if (U.ActualizarUsuario() == true)
                    {
                        Empleados E = new Empleados();
                        E.Id_empleado = (int)dgvEmpleados.CurrentRow.Cells[0].Value;
                        E.Nombre_Empleado = txtNombre.Text;
                        E.Apellido = txtApellido.Text;
                        E.Telefono = txtTelefono.Text;
                        E.Dui = txtDui.Text;
                        E.Correo = txtCorreo.Text;
                        E.Cargo = txtCargo.Text;
                        E.Id_Usuario = Usuario.ConseguirIdUsuario(txtNombreUsuario.Text);

                        if (E.ActualizarEmpleado() == true)
                        {
                            MessageBox.Show("Empleado actualizado satisfactoriamente", "Éxito");
                            MostrarEmpleados();
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("Se produjo un error fatal", "Advertencia");
                        }
                        MostrarEmpleados();
                    }
                    else
                    {
                        MessageBox.Show("Se produjo un error", "Advertencia");
                    }
                    MostrarEmpleados();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MostrarEmpleados();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvEmpleados.DataSource = null;
                dgvEmpleados.DataSource = Empleados.Buscar(txtBuscar.Text);

                dgvEmpleados.Columns[0].Visible = false;
                dgvEmpleados.Columns[1].Visible = false;
                dgvEmpleados.Columns[4].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
