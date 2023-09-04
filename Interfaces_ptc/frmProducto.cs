using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaces_ptc
{
    public partial class frmProducto : Form
    {
        public frmProducto(Usuario u)
        {
            InitializeComponent();

            if (u.Id_Rol == 2)
            {
                btnEliminar.Visible = false;
           
            }
           
            else if (u.Id_Rol == 4)
            {
                btnEliminar.Visible = false; 
                btnAgregar.Visible= false;  
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            CargarProv();
            MostrarProductos();
            cbProveedor.SelectedIndex = -1;
            Actualizar();

        }
        private void MostrarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Producto.CargarProducto();
            dgvProductos.Columns[6].Visible = false;

        }
        private void CargarProv()
        {
            //Manejo de excepciones 
            //El código que puede dar error
            try
            {
                cbProveedor.DataSource = null;
                cbProveedor.DataSource = Proveedores.CargarProveedores();

                //El valor que se muestra en el combobox
                //Se coloca el nombre de la columna en la tabla
                cbProveedor.DisplayMember = "Nombre";

                //Valor que no se muestra (id)
                //Se coloca el nombre de la columna en la tabla
                cbProveedor.ValueMember = "Id_Proveedor";
            }

            //Bloque de código por si da error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvProductos_DoubleClick(object sender, EventArgs e)
        {
            txtNombre.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
            txtStock.Text = dgvProductos.CurrentRow.Cells[3].Value.ToString();
            cbProveedor.Text = dgvProductos.CurrentRow.Cells[5].Value.ToString();
            txtPrecio.Text = dgvProductos.CurrentRow.Cells[4].Value.ToString();

            string ruta = (string)dgvProductos.CurrentRow.Cells[6].Value;

            pbImagen.Image = Image.FromFile(ruta);

        }
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtStock.Text = "";
            txtPrecio.Text = "";
            cbProveedor.SelectedIndex = -1;
            pbImagen.Image = null;
            ofdImagen.Reset();

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (pbImagen.Image != null)
            {
                string rutaImagen = ofdImagen.FileName;
                string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string carpetaDestino = Path.Combine(escritorio, "Imagenes");

                Directory.CreateDirectory(carpetaDestino);

                string imagenDestino = Path.Combine(carpetaDestino, Guid.NewGuid().ToString() + Path.GetExtension(rutaImagen));
                File.Copy(rutaImagen, imagenDestino);

                try
                {
                    if (txtNombre.Text == "" || txtDescripcion.Text == "" || txtStock.Text == "" || txtPrecio.Text == "")
                    {
                        MessageBox.Show("No dejar campos vacíos",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Producto p = new Producto();
                        p.Nombre = txtNombre.Text;
                        p.Descripcion = txtDescripcion.Text;
                        p.Stock = int.Parse(txtStock.Text);
                        p.Id_Proveedor = (int)cbProveedor.SelectedValue;
                        p.PrecioUnitario = double.Parse(txtPrecio.Text);
                        p.Imagen = imagenDestino;
                        if (p.InsertarProducto() == true)
                        {
                            MessageBox.Show("Producto agregado satisfactoriamente", "Éxito");
                            MostrarProductos();
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("Se produjo un error", "Advertencia");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MostrarProductos();
            }
            else
            {
                try
                {
                    if (txtNombre.Text == "" || txtDescripcion.Text == "" || txtStock.Text == "" || txtPrecio.Text == "")
                    {
                        MessageBox.Show("No dejar campos vacíos",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Producto p = new Producto();
                        p.Nombre = txtNombre.Text;
                        p.Descripcion = txtDescripcion.Text;
                        p.Stock = int.Parse(txtStock.Text);
                        p.Id_Proveedor = (int)cbProveedor.SelectedValue;
                        p.PrecioUnitario = double.Parse(txtPrecio.Text);
                        p.Imagen = "";
                        if (p.InsertarProducto() == true)
                        {
                            MessageBox.Show("Producto agregado satisfactoriamente", "Éxito");
                            MostrarProductos();
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("Se produjo un error", "Advertencia");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvProductos.CurrentRow.Cells[0].Value.ToString());
            Producto p = new Producto();
            if (p.EliminarProducto(id) == true)
            {
                MessageBox.Show("Producto eliminado satisfactoriamente", "Éxito");
                MostrarProductos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Se produjo un error", "Advertencia");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (pbImagen.Image != null)
            {
                string rutaImagen = ofdImagen.FileName;
                string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string carpetaDestino = Path.Combine(escritorio, "Imagenes");

                Directory.CreateDirectory(carpetaDestino);

                string imagenDestino = Path.Combine(carpetaDestino, Guid.NewGuid().ToString() + Path.GetExtension(rutaImagen));
                File.Copy(rutaImagen, imagenDestino);
                {
                    try
                    {
                        if (txtNombre.Text == "" || txtDescripcion.Text == "" || txtStock.Text == "" || txtPrecio.Text == "")
                        {
                            MessageBox.Show("No dejar campos vacíos",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Producto p = new Producto();
                            p.Nombre = txtNombre.Text;
                            p.Descripcion = txtDescripcion.Text;
                            p.Stock = int.Parse(txtStock.Text);
                            p.PrecioUnitario = double.Parse(txtPrecio.Text);
                            p.Imagen = imagenDestino;
                            p.Id_Proveedor = (int)cbProveedor.SelectedValue;
                            p.Id_Producto = (int)dgvProductos.CurrentRow.Cells[0].Value;
                            if (p.ActualizarProducto() == true)
                            {
                                MessageBox.Show("Producto actualizado satisfactoriamente", "Éxito");
                                MostrarProductos();
                                LimpiarCampos();
                            }
                            else
                            {
                                MessageBox.Show("Se produjo un error", "Advertencia");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    MostrarProductos();
                }
            }
            else
            {
                try
                {
                    if (txtNombre.Text == "" || txtDescripcion.Text == "" || txtStock.Text == "" || txtPrecio.Text == "")
                    {
                        MessageBox.Show("No dejar campos vacíos",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Producto p = new Producto();
                        p.Nombre = txtNombre.Text;
                        p.Descripcion = txtDescripcion.Text;
                        p.Stock = int.Parse(txtStock.Text);
                        p.PrecioUnitario = double.Parse(txtPrecio.Text);
                        p.Imagen = "";
                        p.Id_Proveedor = (int)cbProveedor.SelectedValue;
                        p.Id_Producto = (int)dgvProductos.CurrentRow.Cells[0].Value;
                        if (p.ActualizarProducto() == true)
                        {
                            MessageBox.Show("Producto actualizado satisfactoriamente", "Éxito");
                            MostrarProductos();
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("Se produjo un error", "Advertencia");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MostrarProductos();
            }

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter es un número o el punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                MessageBox.Show("Solo números y punto decimal son permitidos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }

            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf('.') > -1)
            {
                MessageBox.Show("Solo se permite un punto decimal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter es un número
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Solo números son permitidos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            ofdImagen.Filter = "Archivos De Imagen | *.jpg; *.png; *.jpeg; *.png";

            try
            {
                if (ofdImagen.ShowDialog() == DialogResult.OK)
                {
                    string ruta = ofdImagen.FileName;
                    pbImagen.Image = Image.FromFile(ruta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }
        private void Actualizar()
        {
            dgvProductos.DataSource = Producto.Buscar(txtBuscar.Text);
        }
    }
}
