using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Cargo
    {
        private int id_cargo;
        private string nombre;

        public int Id_cargo { get => id_cargo; set => id_cargo = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public static DataTable CargarCargos()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "select * from Cargo;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }
        public bool InsertarCargos()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "Insert into Cargo(nombre)" + "values(@nombre);";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }
        public bool EliminarCargos(int id)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "DELETE FROM Cargo WHERE Id_Cargo = @id";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@id", id);
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
