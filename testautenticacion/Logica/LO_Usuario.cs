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
        public Usuarios1 EncontrarUsuario(string correo, string clave) {

            Usuarios1 objeto = new Usuarios1();


            using (SqlConnection conexion = new SqlConnection("Data Source=(local) ; Initial Catalog=AADFLD; Integrated Security=true")) {

                string query = "select Nombres,Correo,Clave,IdRol from USUARIOS where Correo = @pcorreo and Clave = @pclave";

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