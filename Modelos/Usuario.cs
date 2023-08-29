using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Usuario
    {
        private int id_usuario;
        private string nombreUsuario;
        private string contraseña;
        private int id_Rol;
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public int Id_Rol { get => id_Rol; set => id_Rol = value; }

        public Usuario IniciarSesion()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "select * from usuario  WHERE NombreUsuario = @nombre AND contraseña = @contraseña;";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@nombre", nombreUsuario);
            cmd.Parameters.AddWithValue("@contraseña", contraseña);

            SqlDataReader rd = cmd.ExecuteReader();

            //Verificamos si hay algún usuario con esa clave
            if (rd.Read())
            {
                Usuario u = new Usuario();
                u.id_usuario = (int)rd[0]; //Lector en posición 0
                u.nombreUsuario = (string)rd[1];
                u.Id_Rol = (int)rd[3];

                return u;
            }
            else
            {
                return null;
            }
        }
        public static int ConseguirIdUsuario(string nombreUsuario)
        {           
                SqlConnection con = Conexion.Conectar();
                string comando = "select * from usuario where NombreUsuario= @nombre;\r\n";
                SqlCommand cmd = new SqlCommand(comando, con);
                cmd.Parameters.AddWithValue("@nombre", nombreUsuario);
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    
                    return (int)rd[0]; //Lector en posición 0
                    
                }
                else
                {
                    return 0;
                }
            
        }
            public bool InsertarUsuario()
            {
                SqlConnection con = Conexion.Conectar();
                string comando = "insert into Usuario(NombreUsuario, contraseña,id_Rol) values\r\n" +
                    "(@nombre, @contraseña, @rol)";
                SqlCommand cmd = new SqlCommand(comando, con);

                cmd.Parameters.AddWithValue("@nombre", nombreUsuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                cmd.Parameters.AddWithValue("@rol", id_Rol);


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
