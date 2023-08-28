using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Modelos
{
    public class Clientes
    {
        private int id_Cliente;
        private string nombre;
        private string apellido;
        private string dui;
        private string telefono;
        private string direccion;
        private int edad;

        public int Id_Cliente { get => id_Cliente; set => id_Cliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Edad { get => edad; set => edad = value; }

        public static DataTable CargarClientes()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "select * from Cliente;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }

        public bool insertarCiente()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "insert into Cliente(Nombre, Apellido, DUI, Telefono, Dirección, Edad) values \r\n" +
                "(@nombre, @apellido, @dui, @telefono, @dirección, @edad)";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@dui", dui);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@dirección", direccion);
            cmd.Parameters.AddWithValue("@edad", edad);

            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        public bool EliminarCliente(int Id)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "DELETE FROM Cliente WHERE Id_Cliente = @Id_Cliente";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@Id_Cliente", Id);

            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ActualizarCliente()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "update cliente \r\n set nombre = @nombre,apellido=@apellido, dui=@dui, " +
                "telefono= @telefono, dirección= @dirección, edad=@edad WHERE id_cliente = @id";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@dui", dui);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@dirección", direccion);
            cmd.Parameters.AddWithValue("@edad", edad);
            cmd.Parameters.AddWithValue("@id", id_Cliente);

            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
