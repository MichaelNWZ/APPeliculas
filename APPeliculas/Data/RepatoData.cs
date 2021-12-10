using APPeliculas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APPeliculas.Data
{
    public class RepatoData
    {
        public static bool Registrar(Reparto cReparto)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Reparto(IdPelicula,IdActor) VALUES (@IdPelicula, @IdActor)", oConexion);
                cmd.Parameters.AddWithValue("@IdPelicula", cReparto.IdPelicula);
                cmd.Parameters.AddWithValue("@IdActor", cReparto.IdActor);

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
        public static bool Modificar(Reparto cReparto)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("UPDATE dbo.Reparto SET IdPelicula = @IdPelicula, IdActor = @IdActor WHERE Id = @Id", oConexion);
                cmd.Parameters.AddWithValue("@Id", cReparto.Id);
                cmd.Parameters.AddWithValue("@Nombre", cReparto.IdPelicula);
                cmd.Parameters.AddWithValue("@anio", cReparto.IdActor);

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
        public static List<NombresReparto> Listar()
        {
            List<NombresReparto> oListReparto = new List<NombresReparto>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT Actor.nombre as nombre_Actor, peliculas.Nombre as Nombre_Pelicula
                    FROM Reparto
                    INNER JOIN Actor ON (Actor.Id = Reparto.IdActor)
                    INNER JOIN Peliculas ON (Peliculas.Id = Reparto.IdPelicula);", oConexion);
                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                          
                            oListReparto.Add(new NombresReparto()
                            {
                                Nombre_Pelicula = (dr["Nombre_Pelicula"]).ToString(),
                                Nombre_Actor = (dr["nombre_Actor"]).ToString()
                            }); ;
                        }
                    }
                    return oListReparto;
                }
                catch (Exception ex)
                {

                    return oListReparto;
                }
            }
        }
        public static bool Eliminar(Reparto cReparto)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Reparto WHERE id = @Id; ", oConexion);
                cmd.Parameters.AddWithValue("@Id", cReparto.Id);
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
    }
}
