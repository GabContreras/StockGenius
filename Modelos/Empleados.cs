using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Empleados
    {
        private int id;
        private string nombre;
        private string apellido;
        private string telefono;
        private string dui;
        private string correo;
        private int id_Cargo;
        private int id_Usuario;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Correo { get => correo; set => correo = value; }
        public int Id_Cargo { get => id_Cargo; set => id_Cargo = value; }
        public int Id_Usuario { get => id_Usuario; set => id_Usuario = value; }

        public static DataTable CargarEmpleados()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "select * from Empleado;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }
    }
}
