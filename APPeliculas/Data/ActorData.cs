using APPeliculas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace APPeliculas.Data
{
    public class ActorData
    {
        public static bool Registrar(Actor cActor)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Actor(Nombre,Apellido,Fecha_de_Naciemiento) VALUES (@Nombre,@Apellido, @Fecha_de_Naciemiento)", oConexion);
                cmd.Parameters.AddWithValue("@Nombre", cActor.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", cActor.Apellido);
                cmd.Parameters.AddWithValue("@Fecha_de_Naciemiento", cActor.Fecha_de_Naciemiento);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }

        public static bool Modificar(Actor cActor)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("UPDATE dbo.Actor SET Nombre = @Nombre, Apellido = @Apellido, Fecha_de_Naciemiento = @Fecha_de_Naciemiento WHERE Id = @Id", oConexion);
                cmd.Parameters.AddWithValue("@Id", cActor.Id);
                cmd.Parameters.AddWithValue("@Nombre", cActor.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", cActor.Apellido);
                cmd.Parameters.AddWithValue("@Fecha_de_Naciemiento", cActor.Fecha_de_Naciemiento);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }

        }

        public static List<Actor> Listar()
        {
            List<Actor> oListActor = new List<Actor>();
            using(SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [PruebaPeliculas].[dbo].[Actor]", oConexion);
                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListActor.Add(new Actor()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Fecha_de_Naciemiento =Convert.ToDateTime(dr["Fecha_de_Naciemiento"])
                            }); ;
                        }
                    }
                    return oListActor;
                }
                catch (Exception ex)
                {

                    return oListActor;
                }
            }
        }
        public static bool Eliminar(Actor cActor)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Actor WHERE id = @Id; ", oConexion);
                cmd.Parameters.AddWithValue("@Id", cActor.Id);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }

        }


        public static List<Actor>Obtener(Actor cActor)
        {
            List<Actor> oListActor = new List<Actor>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Actor WHERE id = @Id; ", oConexion);
                cmd.Parameters.AddWithValue("@Id", cActor.Id);

                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListActor.Add(new Actor()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Fecha_de_Naciemiento = Convert.ToDateTime(dr["Fecha_de_Naciemiento"])
                            }); ;
                        }
                    }
                    return oListActor;
                }
                catch (Exception ex)
                {

                    return oListActor;
                }
            }
        }
    }
}
