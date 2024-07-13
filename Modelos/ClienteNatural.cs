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
    public class ClienteNatural
    {
        private int id_Cliente;
        private string nombre;
        private string apellido;
        private string dui;
        private string telefono;
        private string direccion;
        private int edad;
        private string tipo_cliente;
        private string estado;

        public int Id_Cliente { get => id_Cliente; set => id_Cliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Tipo_cliente { get => tipo_cliente; set => tipo_cliente = value; }
        public string Estado { get => estado; set => estado = value; }

        public static DataTable CargarClientes()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT Id_Cliente as \"Código de cliente\", Nombre, Apellido, DUI, Telefono, Dirección, Edad " +
                "\r\nFROM Cliente\r\n" +
                "WHERE DUI IS NOT NULL AND Apellido IS NOT NULL AND Edad IS NOT NULL AND Estado = 'Activo';";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();
            return dt;

        }
        public static DataTable CargarAmbosClientes()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "select c.Id_Cliente, c.Nombre as Cliente ,c.DUI ,c.Nit as NIT,c.NRC\r\n" +
                "from cliente c\r\n" +
                "where C.Estado= 'Activo'";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();
            return dt;

        }

        public bool insertarCiente()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "insert into Cliente(Nombre, Apellido, DUI, Telefono, Dirección, Edad,Tipo_Cliente,Estado) values \r\n" +
                "(@nombre, @apellido, @dui, @telefono, @dirección, @edad,@Tipo_Cliente,'Activo')";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@dui", dui);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@dirección", direccion);
            cmd.Parameters.AddWithValue("@edad", edad);
            cmd.Parameters.AddWithValue("@Tipo_Cliente", tipo_cliente);
            if (cmd.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }

            else
            {
                con.Close();
                return false;
            }
        }
        public bool EliminarCliente(int Id)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "update Cliente set Estado= 'Inactivo' where Id_Cliente=@Id_Cliente";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@Id_Cliente", Id);

            if (cmd.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
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
                con.Close();
                return true;
            }

            else
            {
                con.Close();
                return false;
            }
        }

        public static DataTable Buscar(string termino)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = $"SELECT Id_Cliente as \"Código de cliente\", Nombre , Apellido, DUI, Telefono, Dirección, Edad \r\n" +
                $"FROM Cliente\r\n" +
                $"WHERE DUI IS NOT NULL AND Apellido IS NOT NULL AND Edad IS NOT NULL AND Estado = 'Activo' and Cliente.nombre like '%{termino}%'";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();
            return dt;

        }
        public static DataTable Buscar2(string termino)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = $"select c.Id_Cliente as \"Código de cliente\",c.Nombre as Cliente,c.DUI ,c.Nit as NIT,c.NRC\r\n" +
                $"from cliente c\r\n" +
                $"where C.Estado= 'Activo' AND c.Nombre like '%{termino}%'";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();
            return dt;

        }
    }
}
