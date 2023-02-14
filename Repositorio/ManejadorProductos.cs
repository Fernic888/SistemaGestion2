using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationPrueba
{
    internal class ManejadorProductos
    {
        //dejamos string aca por si lo necesitamos mas adelante
        public static string cadenaConexion = "Data Source=ZUREO-NF\\SQLEXPRESS01;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Producto> ObtenerProductos(long id)
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("Select * from Producto where IdUsuario=@id", conn); 
                comando.Parameters.AddWithValue("id", id);
                conn.Open();

                SqlDataReader reader = comando.ExecuteReader(); 
                if (reader.HasRows) 
                {
                    while (reader.Read()) 
                    {
                        Producto prodTemporal = new Producto();
                        prodTemporal.Id = reader.GetInt64(0); 
                        prodTemporal.Descripciones = reader.GetString(1);
                        prodTemporal.Costo = (double)reader.GetDecimal(2); 
                        prodTemporal.PrecioVenta = (double)reader.GetDecimal(3);
                        prodTemporal.Stock = reader.GetInt32(4);
                        prodTemporal.IdUsuario = reader.GetInt64(5);

                        productos.Add(prodTemporal);
                    }
                }
                return productos;
            }

        }
        
    }
}
