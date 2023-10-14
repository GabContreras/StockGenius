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

        Usuario v;
        
        public frmEmpleados(Usuario u)
        {
            InitializeComponent();

            v= u;
          
           if (v.Id_Rol== 2)
           {
                btnEliminar.Visible = false;
                btnActualizar.Visible = false;
                btnAgregar.Visible = false;
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
                if (v.Id_Rol == 6)
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
                if (v.Id_Rol == 1)
                {
                    cbRol.DataSource = null;
                    cbRol.DataSource = Roles.CargarRolesSiEsAdmin();

                    //El valor que se muestra en el combobox
                    //Se coloca el nombre de la columna en la tabla
                    cbRol.DisplayMember = "nombre";

                    //Valor que no se muestra (id)
                    //Se coloca el nombre de la columna en la tabla
                    cbRol.ValueMember = "id";
                }

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
            cbRol.SelectedIndex = -1;
            Actualizar();

        }
        private void MostrarEmpleados()
        {
            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = Empleado.CargarEmpleados();

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
            cbRol.SelectedIndex = -1;
            txtBuscar.Text = "";

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) || txtContraseña.Text == "" || 
                    string.IsNullOrWhiteSpace(txtCargo.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) 
                    || string.IsNullOrWhiteSpace(txtApellido.Text)|| string.IsNullOrWhiteSpace(txtTelefono.Text) 
                    || string.IsNullOrWhiteSpace(txtDui.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text)
                    )
                {
                    MessageBox.Show("No dejar campos vacíos",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!txtCorreo.Text.Contains("@"))
                {
                    MessageBox.Show("El campo de correo debe contener el símbolo '@'",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        Empleado E = new Empleado();
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
        }

        private void frmEmpleados_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
             try
            {
                if (v.Id_Rol == 1)
                {
                    MessageBox.Show("No le puedes cambiar los datos a un Administrador",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else {
                    int idU = int.Parse(dgvEmpleados.CurrentRow.Cells[2].Value.ToString());
                    Usuario U = new Usuario();
                    if (U.EliminarUsuario(idU) == true)
                    {
                        MessageBox.Show("Empleado inhabilitado satisfactoriamente", "Éxito");
                        MostrarEmpleados();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Se produjo un error al inhabilitar el empleado", "Advertencia");
                    } 
                }       
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Por favor, seleccione un empleado antes de inhabilitarlo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (v.Id_Rol == 1)
                {
                    if (txtNombreUsuario.Text == "" || txtCargo.Text == "" || txtNombre.Text == "" || txtApellido.Text == ""
                    || txtTelefono.Text == "" || txtDui.Text == "" || txtCorreo.Text == "")
                    {
                        MessageBox.Show("No dejar campos vacíos",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (!txtCorreo.Text.Contains("@"))
                    {
                        MessageBox.Show("El campo de correo debe contener el símbolo '@'",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        int id_Admin = int.Parse(dgvEmpleados.CurrentRow.Cells[1].Value.ToString());
                        if (id_Admin == 1)
                        {
                            MessageBox.Show("No le puedes cambiar los datos a un Administrador",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            Encrypt encr = new Encrypt();

                            Usuario U = new Usuario();
                            U.NombreUsuario = txtNombreUsuario.Text;
                            U.Id_Rol = (int)cbRol.SelectedValue;
                            U.Id_usuario = (int)dgvEmpleados.CurrentRow.Cells[2].Value;
                            U.Contraseña = encr.Encriptar(txtContraseña.Text);
                            // Verificar si la contraseña no está vacía y actualizar el usuario
                            if (txtContraseña.Text == "")
                            {
                                if (U.ActualizarUsuarioConTxtContraseñaVacio() == true)
                                {
                                    Empleado E = new Empleado();
                                    E.Id_empleado = (int)dgvEmpleados.CurrentRow.Cells[0].Value;
                                    E.Nombre_Empleado = txtNombre.Text;
                                    E.Apellido = txtApellido.Text;
                                    E.Telefono = txtTelefono.Text;
                                    E.Dui = txtDui.Text;
                                    E.Correo = txtCorreo.Text;
                                    E.Cargo = txtCargo.Text;
                                    E.Id_Usuario = Usuario.ConseguirIdUsuario(txtNombreUsuario.Text);

                                    // Actualizar el empleado después de actualizar el usuario
                                    if (E.ActualizarEmpleado())
                                    {
                                        MessageBox.Show("Empleado actualizado satisfactoriamente", "Éxito");
                                        MostrarEmpleados();
                                        LimpiarCampos();
                                    }
                                }
                            }

                            else if (U.ActualizarUsuario() == true)
                            {
                                Empleado E = new Empleado();
                                E.Id_empleado = (int)dgvEmpleados.CurrentRow.Cells[0].Value;
                                E.Nombre_Empleado = txtNombre.Text;
                                E.Apellido = txtApellido.Text;
                                E.Telefono = txtTelefono.Text;
                                E.Dui = txtDui.Text;
                                E.Correo = txtCorreo.Text;
                                E.Cargo = txtCargo.Text;
                                E.Id_Usuario = Usuario.ConseguirIdUsuario(txtNombreUsuario.Text);

                                // Actualizar el empleado después de actualizar el usuario
                                if (E.ActualizarEmpleado())
                                {
                                    MessageBox.Show("Empleado actualizado satisfactoriamente", "Éxito");
                                    MostrarEmpleados();
                                    LimpiarCampos();
                                }

                            }
                        }
                    }
                }
                else
                {

                    if (txtNombreUsuario.Text == "" || txtCargo.Text == "" || txtNombre.Text == "" || txtApellido.Text == ""
                        || txtTelefono.Text == "" || txtDui.Text == "" || txtCorreo.Text == "")
                    {
                        MessageBox.Show("No dejar campos vacíos",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (!txtCorreo.Text.Contains("@"))
                    {
                        MessageBox.Show("El campo de correo debe contener el símbolo '@'",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        Encrypt encr = new Encrypt();

                        Usuario U = new Usuario();
                        U.NombreUsuario = txtNombreUsuario.Text;
                        U.Id_Rol = (int)cbRol.SelectedValue;
                        U.Id_usuario = (int)dgvEmpleados.CurrentRow.Cells[2].Value;
                        U.Contraseña = encr.Encriptar(txtContraseña.Text);
                        // Verificar si la contraseña no está vacía y actualizar el usuario
                        if (txtContraseña.Text == "")
                        {
                            if (U.ActualizarUsuarioConTxtContraseñaVacio() == true)
                            {
                                Empleado E = new Empleado();
                                E.Id_empleado = (int)dgvEmpleados.CurrentRow.Cells[0].Value;
                                E.Nombre_Empleado = txtNombre.Text;
                                E.Apellido = txtApellido.Text;
                                E.Telefono = txtTelefono.Text;
                                E.Dui = txtDui.Text;
                                E.Correo = txtCorreo.Text;
                                E.Cargo = txtCargo.Text;
                                E.Id_Usuario = Usuario.ConseguirIdUsuario(txtNombreUsuario.Text);

                                // Actualizar el empleado después de actualizar el usuario
                                if (E.ActualizarEmpleado())
                                {
                                    MessageBox.Show("Empleado actualizado satisfactoriamente", "Éxito");
                                    MostrarEmpleados();
                                    LimpiarCampos();
                                }
                            }
                        }

                        else if (U.ActualizarUsuario() == true)
                        {
                            Empleado E = new Empleado();
                            E.Id_empleado = (int)dgvEmpleados.CurrentRow.Cells[0].Value;
                            E.Nombre_Empleado = txtNombre.Text;
                            E.Apellido = txtApellido.Text;
                            E.Telefono = txtTelefono.Text;
                            E.Dui = txtDui.Text;
                            E.Correo = txtCorreo.Text;
                            E.Cargo = txtCargo.Text;
                            E.Id_Usuario = Usuario.ConseguirIdUsuario(txtNombreUsuario.Text);

                            // Actualizar el empleado después de actualizar el usuario
                            if (E.ActualizarEmpleado())
                            {
                                MessageBox.Show("Empleado actualizado satisfactoriamente", "Éxito");
                                MostrarEmpleados();
                                LimpiarCampos();
                            }

                        }
                    }
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Por favor, seleccione un empleado antes de actualizar sus datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         

        }
        private void Actualizar()
        {
            dgvEmpleados.DataSource = Empleado.Buscar(txtBuscar.Text);

            dgvEmpleados.Columns[0].Visible = false;
            dgvEmpleados.Columns[1].Visible = false;
            dgvEmpleados.Columns[2].Visible = false;
            dgvEmpleados.Columns[10].Visible = false;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
        }

        private void txtCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo letras y espacios en blanco
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Solo letras son permitidas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // Suprime el carácter
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo letras y espacios en blanco
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Solo letras son permitidas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // Suprime el carácter
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo letras y espacios en blanco
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                MessageBox.Show("Solo letras son permitidas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // Suprime el carácter
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTelefonoDatos(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números (0-9), guiones (-), un símbolo de más (+) y espacios.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '+' && e.KeyChar != ' ')
            {
                MessageBox.Show("Solo números, '-', '+', son permitidos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // Suprime el carácter
            }

            // Verificar si se ha ingresado más de un símbolo de más (+).
            if (e.KeyChar == '+' && (sender as System.Windows.Forms.TextBox).Text.Contains("+"))
            {
                MessageBox.Show("Solo se permite un símbolo +", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; // Suprime el carácter
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void probando(object sender, EventArgs e)
        {
            try
            {
                txtNombreUsuario.Text = dgvEmpleados.CurrentRow.Cells[9].Value.ToString();
                cbRol.Text = dgvEmpleados.CurrentRow.Cells[3].Value.ToString();
                txtCargo.Text = dgvEmpleados.CurrentRow.Cells[11].Value.ToString();
                txtNombre.Text = dgvEmpleados.CurrentRow.Cells[4].Value.ToString();
                txtApellido.Text = dgvEmpleados.CurrentRow.Cells[5].Value.ToString();
                txtTelefono.Text = dgvEmpleados.CurrentRow.Cells[6].Value.ToString();
                txtDui.Text = dgvEmpleados.CurrentRow.Cells[7].Value.ToString();
                txtCorreo.Text = dgvEmpleados.CurrentRow.Cells[8].Value.ToString();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Por favor, seleccione a un Empleado antes de cargar sus datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter presionado es un espacio en blanco
            if (e.KeyChar == ' ')
            {
                MessageBox.Show("La contraseña no puede contener espacios en blanco.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true; // Evitar la entrada de espacios en blanco
            }
        }
    }
}

