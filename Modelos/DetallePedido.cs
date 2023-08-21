﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Modelos
{
    public class DetallePedido
    {
        private int id_Detalle;
        private int id_pedido;
        private int id_Producto;
        private int cantidad;
        private double total;

        public int Id_Detalle { get => id_Detalle; set => id_Detalle = value; }
        public int Id_pedido { get => id_pedido; set => id_pedido = value; }
        public int Id_Producto { get => id_Producto; set => id_Producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Total { get => total; set => total = value; }

        public static DataTable CargarDetallePedido()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT DP.Id_Detalle, DP.Id_Pedido, DP.Id_Producto, P.Nombre AS Nombre_Producto, DP.cantidad, P.PrecioUnitario,\r\n" +
                "DP.cantidad * P.PrecioUnitario AS Total\r\nFROM Detalle_Pedido DP\r\nINNER JOIN Producto P ON DP.Id_Producto = P.Id_Producto;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }
        public bool InsertarDpedido()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "INSERT INTO Detalle_Pedido(Id_Pedido, Id_Producto, cantidad) VALUES (@Id_Pedido, @Id_Producto, @cantidad)";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@Id_Pedido", id_pedido);
            cmd.Parameters.AddWithValue("@Id_Producto", id_Producto);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);

            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EliminarDetallePedido(int Id)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "DELETE FROM Detalle_Pedido WHERE Id_Detalle = @Id_Detalle";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@Id_Detalle", Id);

            return cmd.ExecuteNonQuery() > 0;
        }
        public void ActualizarStockProducto(int productoId, int cantidad)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "UPDATE Producto SET Stock = Stock + @Cantidad WHERE Id_Producto = @Id_Producto";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@Cantidad", cantidad);
            cmd.Parameters.AddWithValue("@Id_Producto", productoId);
            cmd.ExecuteNonQuery();
        }
        public bool ActualizarDPedido()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "UPDATE Detalle_Pedido\r\n " +
                             "SET Id_Pedido = @Id_Pedido, Id_Producto = @Id_Producto, cantidad = @cantidad\r\n " +
                             "WHERE Id_Detalle = @id";

            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@Id_Pedido", id_pedido);
            cmd.Parameters.AddWithValue("@Id_Producto", id_Producto);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.Parameters.AddWithValue("@id", Id_Detalle);

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
