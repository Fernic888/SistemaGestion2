using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationPrueba
{
    internal class ManejadorProdVendidos

    {
        public static string cadenaConexion = "Data Source=ZUREO-NF\\SQLEXPRESS01;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<Producto> ObtenerProductosVendidos(long id)
        {
            List<Producto> prodVendidos = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                SqlCommand comando = new SqlCommand("  select  Venta.IdUsuario, Producto.Descripciones from venta" +
                    "  inner join ProductoVendido  on venta.Id=ProductoVendido.IdVenta" +
                    "  inner join Producto on Producto.id=ProductoVendido.IdProducto " +
                    "  where Venta.IdUsuario=@id", conn);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto prodVendidoTemporal = new Producto();
                        prodVendidoTemporal.Descripciones = reader.GetString(1);
                        //Console.WriteLine(prodVendidoTemporal.Descripciones);
                        prodVendidos.Add(prodVendidoTemporal);
                    }
                    
                }


                return prodVendidos;
            }




        }

    }
}
