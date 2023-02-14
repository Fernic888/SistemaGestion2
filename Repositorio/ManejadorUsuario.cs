using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApplicationPrueba
{
    internal class ManejadorUsuario
    {
        public static string cadenaConexion = "Data Source=ZUREO-NF\\SQLEXPRESS01;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static Usuario ObtenerUsuario(long id)
        {
            Usuario usuario = new Usuario();
            using (SqlConnection conn=new SqlConnection(cadenaConexion))
            {
                conn.Open();    
                SqlCommand comando = new SqlCommand("Select * from Usuario where id=@id", conn);
                comando.Parameters.AddWithValue("id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    {

                        usuario.Id = (int)reader.GetInt64(0); //reader.GetInt64(0);
                        usuario.Nombre = reader.GetString(1);
                        usuario.Apellido = reader.GetString(2);
                        usuario.NombreUsuario = reader.GetString(3);
                        usuario.Contrasena = reader.GetString(4);
                        usuario.Mail = reader.GetString(5);



                    }
                }
                
                return usuario;
            }
            
        }
        public static Usuario IniciarSesion(string nombre, string contrasena)
        {
            Usuario usuario = new Usuario();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                SqlCommand comando = new SqlCommand("Select * from Usuario where Nombre=@nombre ", conn);
                comando.Parameters.AddWithValue("@nombre", nombre);
                SqlDataReader reader= comando.ExecuteReader();
                
                if (reader.HasRows)
                {
                    reader.Read();
                    usuario.Id = (int)reader.GetInt64(0); //reader.GetInt64(0);
                    usuario.Nombre = reader.GetString(1);
                    usuario.Apellido = reader.GetString(2);
                    usuario.NombreUsuario = reader.GetString(3);
                    usuario.Contrasena = reader.GetString(4);
                    usuario.Mail = reader.GetString(5);
                }
                else
                {
                    usuario.Id = 0; 
                    usuario.Nombre = " ";
                    usuario.Apellido = " ";
                    usuario.NombreUsuario = " ";
                    usuario.Contrasena = " ";
                    usuario.Mail = " ";
                }
                if (contrasena != usuario.Contrasena)
                {
                    usuario.Id = 0; 
                    usuario.Nombre = " ";
                    usuario.Apellido = " ";
                    usuario.NombreUsuario = " ";
                    usuario.Contrasena = " ";
                    usuario.Mail = " ";
                }

            }
            return usuario;
        }
        public static int InsertarUsuario(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Usuario(Nombre, Apellido, NombreUsuario, Contraseña, Mail) " +
                    "VALUES (@nombre, @apellido, @nombreUsuario, @contrasena, @mail)", conn);
                SqlParameter nombreParam = new SqlParameter();
                nombreParam.ParameterName = "nombre";
                nombreParam.SqlDbType = SqlDbType.VarChar;
                nombreParam.Value = usuario.Nombre;

                SqlParameter apellidoParam = new SqlParameter("apellido", usuario.Apellido);
                SqlParameter nombreUsuParam = new SqlParameter("nombreUsuario", usuario.NombreUsuario);
                SqlParameter passwParam = new SqlParameter("contrasena", usuario.Contrasena);
                SqlParameter mailParam = new SqlParameter("mail", usuario.Mail);

                cmd.Parameters.Add(nombreParam);
                cmd.Parameters.Add(apellidoParam);
                cmd.Parameters.Add(nombreUsuParam);
                cmd.Parameters.Add(passwParam);
                cmd.Parameters.Add(mailParam);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        //internal static void InsertarUsuario(Usuario usuario)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
