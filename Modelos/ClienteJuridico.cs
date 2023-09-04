using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ClienteJuridico
    {
        private int id_cliente;
        private string nombreEmpresa;
        private string nIT;
        private string nRC;
        private string giro;
        private string categoria;
        private string direccion;
        private string telefono;

        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public string NombreEmpresa { get => nombreEmpresa; set => nombreEmpresa = value; }
        public string NIT { get => nIT; set => nIT = value; }
        public string NRC { get => nRC; set => nRC = value; }
        public string Giro { get => giro; set => giro = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }


        public static DataTable CargarClientes()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT Id_Cliente, Nombre as \"NombreEmpresa\", Apellido, DUI, Telefono, Dirección, Edad, NIT, NRC, Giro, Categoria\r\n" +
                "FROM Cliente\r\n" +
                "WHERE NIT IS NOT NULL AND NRC IS NOT NULL AND Giro IS NOT NULL AND Categoria IS NOT NULL;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }


        public bool insertarCiente()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "insert into Cliente(Nombre,Telefono,Dirección,NIT,NRC,Giro,Categoria) values \r\n" +
                "(@nombre, @Telefono, @Dirección, @NIT, @NRC, @Giro,@Categoria)";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@nombre", nombreEmpresa);
            cmd.Parameters.AddWithValue("@Telefono", telefono);
            cmd.Parameters.AddWithValue("@Dirección", direccion);
            cmd.Parameters.AddWithValue("@NIT", nIT);
            cmd.Parameters.AddWithValue("@NRC", nRC);
            cmd.Parameters.AddWithValue("@Giro", giro);
            cmd.Parameters.AddWithValue("@Categoria", categoria);

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
