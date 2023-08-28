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
    public class Empleados:Cargo
    {
        private int id;
        private string nombre_Empleado;
        private string apellido;
        private string telefono;
        private string dui;
        private string correo;
        private int id_Cargo;
        private int id_Usuario;

        public int Id { get => id; set => id = value; }

        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Correo { get => correo; set => correo = value; }
        public int Id_Cargo { get => id_Cargo; set => id_Cargo = value; }
        public int Id_Usuario { get => id_Usuario; set => id_Usuario = value; }
        public string Nombre_Empleado { get => nombre_Empleado; set => nombre_Empleado = value; }

        public static DataTable CargarEmpleados()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT U.id_Usuario, E.Id_Empleado, U.NombreUsuario, U.contraseña,E.Nombre AS Nombre, E.Apellido AS Apellido, E.Teléfono AS Teléfono, E.DUI AS DUI, E.Correo AS Correo, C.Nombre AS Cargo\r\nFROM Usuario U\r\nINNER JOIN Empleado E ON U.id_Usuario = E.id_Usuario\r\nINNER JOIN Cargo C ON E.id_Cargo = C.Id_Cargo;\r\n";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }
        public static DataTable CargarEmpleados2()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT Id_Empleado ,concat (Nombre,' ', Apellido, ', ', DUI ) as 'Empleado' from Empleado;\r\n";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }


        public bool InsertarEmpleado()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "insert into Empleado (Nombre, Apellido, Teléfono, DUI, Correo, id_Cargo, id_Usuario) values \r\n" +
                "(@nombre, @apellido, @teléfono, @dui, @correo, @id_Cargo, @id_Usuario)";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@nombre", nombre_Empleado);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@teléfono", telefono);
            cmd.Parameters.AddWithValue("@dui", dui);
            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@id_Cargo", id_Cargo);
            cmd.Parameters.AddWithValue("@id_Usuario", id_Usuario);


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
