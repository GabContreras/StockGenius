using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

                con.Close();
                return u;
            }
            else
            {
                con.Close();
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
                    var x = (int)rd[0];
                    con.Close();
                    return x; //Lector en posición 0
                    
                }
                else
                {
                con.Close();
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
                con.Close();
                return true;
            }

            else
            {
                con.Close();
                return false;
            }
        }
        public bool ActualizarUsuario()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "update Usuario \r\n " +
                "set NombreUsuario=@nombre, contraseña=@contraseña , id_Rol=@rol WHERE id_Usuario = @id";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@nombre", nombreUsuario);
            cmd.Parameters.AddWithValue("@contraseña", contraseña);
            cmd.Parameters.AddWithValue("@rol", id_Rol);
            cmd.Parameters.AddWithValue("@id", id_usuario);
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
        public bool ActualizarContraseña()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "update Usuario \r\n " +
                "set contraseña=@contraseña WHERE id_Usuario = @id";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@contraseña", contraseña);
            cmd.Parameters.AddWithValue("@id", id_usuario);
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
        public bool ActualizarUsuarioConTxtContraseñaVacio()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "update Usuario \r\n " +
                "set NombreUsuario=@nombre,id_Rol=@rol WHERE id_Usuario = @id";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@nombre", nombreUsuario);
            cmd.Parameters.AddWithValue("@rol", id_Rol);
            cmd.Parameters.AddWithValue("@id", id_usuario);
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
        public bool EliminarUsuario(int id)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "DELETE FROM Usuario WHERE id_Usuario = @id";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@id", id);
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
        public (Usuario, Empleado) ObtenerInfo()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT U.Id_usuario, U.NombreUsuario, U.id_Rol, emp.Nombre, emp.Correo " +
                             "FROM Usuario U " +
                             "INNER JOIN Empleado AS emp ON U.Id_Usuario = emp.id_Usuario " +
                             "WHERE U.NombreUsuario = @username";
            SqlCommand cmd = new SqlCommand(comando, con);

            // Enviamos el valor del nombre de usuario para que pueda usarse en el WHERE
            cmd.Parameters.AddWithValue("@username", nombreUsuario);

            // Ejecutamos el lector
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                // Si se obtuvo una coincidencia, creamos un Usuario y un Empleado
                Usuario us = new Usuario();

                 us.id_usuario = (int)rd[0];
                 us.nombreUsuario = (string)rd[1];
                 us.Id_Rol = (int)rd[2];


                Empleado emp = new Empleado();

                    emp.Nombre = (string)rd[3];
                    emp.Correo = (string)rd[4];


                // Retornamos tanto el Usuario como el Empleado en una tupla
                con.Close();
                return (us,emp);
            }
            else
            {
                // Si no hubo coincidencia, retornamos dos valores nulos
                con.Close();
                return (null, null);
            }
        }

        public Usuario ObtenerInfoSoloUsuario()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT Id_usuario, NombreUsuario, id_Rol " +
                             "FROM Usuario " +
                             "WHERE NombreUsuario = @username";
            SqlCommand cmd = new SqlCommand(comando, con);

            // Enviamos el valor del nombre de usuario para que pueda usarse en el WHERE
            cmd.Parameters.AddWithValue("@username", nombreUsuario); // Cambiar 'Admin1' al valor deseado

            // Ejecutamos el lector
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                // Si se obtuvo una coincidencia, creamos un Usuario
                Usuario us = new Usuario
                {
                    id_usuario = (int)rd[0],
                    nombreUsuario = (string)rd[1],
                    Id_Rol = (int)rd[2]
                };

                // Retornamos solo el Usuario
                con.Close();
                return us;
            }
            else
            {
                // Si no hubo coincidencia, retornamos un valor nulo
                con.Close();
                return null;
            }
        }


        public static bool VerificarUsuarios()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "Select * From Usuario";
            SqlCommand cmd = new SqlCommand(comando, con);

            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
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
    }
}
