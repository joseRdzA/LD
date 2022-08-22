using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testautenticacion.Models;
using System.Data.SqlClient;
using System.Data;

namespace testautenticacion.Logica
{
    public class LO_Usuario
    {


        public void activarCuenta(string token,string correo,string clave)
        {
            using (SqlConnection conexion = new SqlConnection("Data Source = (local) ; Initial Catalog=AADFLD; Integrated Security=true"))
            {
                // solo tendra un token activo, al generar uno nuevo desativa cualquier otro q existiera, asociado
                string query = "update  Tokens set Estado='I' where Correo=@pCorreo";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@pCorreo", correo);
                cmd.CommandType = CommandType.Text;
                conexion.Open();
                cmd.ExecuteNonQuery();

            }


            using (SqlConnection conexion = new SqlConnection("Data Source = (local) ; Initial Catalog=AADFLD; Integrated Security=true"))
            {

                string query = "update Usuarios set Clave = @pclave,Estado='A' where Correo=@pcorreo";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@pcorreo", correo);
                cmd.Parameters.AddWithValue("@pclave", clave);
                cmd.CommandType = CommandType.Text;


                conexion.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public string ValidarToken(string token)
        {
            string correo = "";

            using (SqlConnection conexion = new SqlConnection("Data Source = (local)  ; Initial Catalog=AADFLD; Integrated Security=true"))
            {

                string query = "select Correo from Tokens where Token=@ptoken and Estado='A'";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@ptoken", token);
                cmd.CommandType = CommandType.Text;
                conexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        correo = dr["Correo"].ToString();
                    }
                }

            }
            return correo;
        }


            public void guardarToken(string correo,string token)
        {
            int consecutivo = 0;

            using (SqlConnection conexion = new SqlConnection("Data Source = (local)  ; Initial Catalog=AADFLD; Integrated Security=true"))
            {

                string query = "select coalesce(max(idToken),0) consecutivo from Tokens";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.CommandType = CommandType.Text;
                conexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                            consecutivo = Int32.Parse(dr["consecutivo"].ToString())+1;
                    }
                }

            }


            using (SqlConnection conexion = new SqlConnection("Data Source = (local)  ; Initial Catalog=AADFLD; Integrated Security=true"))
            {
                // solo tendra un token activo, al generar uno nuevo desativa cualquier otro q existiera, asociado
                string query = "update  Tokens set Estado='I' where Correo=@pCorreo";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@pCorreo", correo);
                cmd.CommandType = CommandType.Text;
                conexion.Open();
                cmd.ExecuteNonQuery();

            }

            using (SqlConnection conexion = new SqlConnection("Data Source = (local)  ; Initial Catalog=AADFLD; Integrated Security=true"))
            {

                string query = "insert into Tokens(idToken,Token,Correo,Estado) values(@pidToken,@pToken,@pCorreo,@pEstado)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@pidToken", consecutivo);
                cmd.Parameters.AddWithValue("@pToken", token);
                cmd.Parameters.AddWithValue("@pCorreo", correo);
                cmd.Parameters.AddWithValue("@pEstado", 'A');//como el token nunca se ha usado esta en a, por usado para a I, inactivo
                cmd.CommandType = CommandType.Text;
                conexion.Open();
                cmd.ExecuteNonQuery();

            }


        }

        public string validarUsuario(string correo, string clave)
        {
            string estado = "";

            using (SqlConnection conexion = new SqlConnection("Data Source = (local)  ; Initial Catalog=AADFLD; Integrated Security=true"))
            {

                string query = "select Estado  from USUARIOS where Correo = @pcorreo and Clave = @pclave";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@pcorreo", correo);
                cmd.Parameters.AddWithValue("@pclave", clave);
                cmd.CommandType = CommandType.Text;


                conexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        estado = dr["Estado"].ToString();  
                    }
                }
            }
            return estado;
        }


        public Usuarios1 InactivarUsuario( string correo)
        {
            Usuarios1 objeto = new Usuarios1();


            using (SqlConnection conexion = new SqlConnection("Data Source = (local) ; Initial Catalog=AADFLD; Integrated Security=true"))
            {
                //I = inactivo,  A = Activo
                string query = "update Usuarios set Estado = 'I' where Correo=@pcorreo";


                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@pcorreo", correo);
                cmd.CommandType = CommandType.Text;


                conexion.Open();
                cmd.ExecuteNonQuery();



            }
            return objeto;
        }
            


            public Usuarios1 EditarUsuario(string cedula, string correo, string clave) {

            Usuarios1 objeto = new Usuarios1();


            using (SqlConnection conexion = new SqlConnection("Data Source = (local)  ; Initial Catalog=AADFLD; Integrated Security=true"))
            {
                
                string query = "update Usuarios set Clave = @pclave where Correo=@pcorreo and idUsuario = @pidusuario";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@pcorreo", correo);
                cmd.Parameters.AddWithValue("@pclave", clave);
                cmd.Parameters.AddWithValue("@pidusuario", cedula);
                cmd.CommandType = CommandType.Text;
                

                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            return objeto;

            }
        public Usuarios1 EncontrarUsuario(string correo, string clave) {

            Usuarios1 objeto = new Usuarios1();


            using (SqlConnection conexion = new SqlConnection("Data Source = (local) ; Initial Catalog=AADFLD; Integrated Security=true")) {

                string query = "select Nombres,Correo,Clave,IdRol from USUARIOS where Estado = 'A' and Correo = @pcorreo and Clave = @pclave";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@pcorreo", correo);
                cmd.Parameters.AddWithValue("@pclave", clave);
                cmd.CommandType = CommandType.Text;

          
                conexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader()) {

                    while (dr.Read()) {

                        objeto = new Usuarios1()
                        {
                            Nombres = dr["Nombres"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Clave = dr["Clave"].ToString(),
                            IdRol = (Rol1)dr["IdRol"],

                        };
                    }
                
                }
            }
            return objeto;

        }




    }
}