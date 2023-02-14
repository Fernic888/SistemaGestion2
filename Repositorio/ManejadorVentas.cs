using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationPrueba
{
    internal class ManejadorVentas
    {
        public static string cadenaConexion = "Data Source=ZUREO-NF\\SQLEXPRESS01;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Venta> ObtenerVentas(long id)
        {
            List<Venta> ventas = new List<Venta>();

            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                SqlCommand comando = new SqlCommand("Select * from Venta where IdUsuario=@id", conn);
                comando.Parameters.AddWithValue("@id", id);
                

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Venta ventaTemporal = new Venta();

                        ventaTemporal.Id = reader.GetInt64(0);
                        ventaTemporal.Comentarios = reader.GetString(1);
                        ventaTemporal.IdUsuario = reader.GetInt64(2);

                        ventas.Add(ventaTemporal);

                    }
                }
                return ventas;
            }

        }
    }
}
