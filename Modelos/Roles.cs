using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Roles
    {
        private int Id_rol;
        private string nombre;

        public int id_rol { get => id_rol; set => id_rol = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Id_rol1 { get => Id_rol; set => Id_rol = value; }

        public static DataTable CargarRoles()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT U.Id_Usuario, U.NombreUsuario as Usuario, U.contraseña, u.id_Rol, R.Nombre AS Rol\r\n" +
                "FROM Usuario U\r\nINNER JOIN Rol R ON U.id_Rol = R.id_Rol;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }
       
    }
}
