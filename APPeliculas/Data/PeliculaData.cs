using APPeliculas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APPeliculas.Data
{
    public class PeliculaData
    {
        public static bool Registrar(Peliculas cPeliculas)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Peliculas(Nombre,anio) VALUES (@Nombre, @anio)", oConexion);
                cmd.Parameters.AddWithValue("@Nombre", cPeliculas.Nombre);
                cmd.Parameters.AddWithValue("@anio", cPeliculas.anio);

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
        public static bool Modificar(Peliculas cPeliculas)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("UPDATE dbo.Peliculas SET Nombre = @Nombre, anio = @anio WHERE Id = @Id", oConexion);
                cmd.Parameters.AddWithValue("@Id", cPeliculas.Id);
                cmd.Parameters.AddWithValue("@Nombre", cPeliculas.Nombre);
                cmd.Parameters.AddWithValue("@anio", cPeliculas.anio);

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
        public static List<Peliculas> Listar()
        {
            List<Peliculas> oListPeliculas = new List<Peliculas>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [PruebaPeliculas].[dbo].[Peliculas]", oConexion);
                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListPeliculas.Add(new Peliculas()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                anio = Convert.ToDateTime(dr["anio"])
                            }); ;
                        }
                    }
                    return oListPeliculas;
                }
                catch (Exception ex)
                {

                    return oListPeliculas;
                }
            }
        }
        public static bool Eliminar(Peliculas cPeliculas)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Peliculas WHERE id = @Id; ", oConexion);
                cmd.Parameters.AddWithValue("@Id", cPeliculas.Id);
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
        public static List<Peliculas> Obtener(Peliculas cPeliculas)
        {
            List<Peliculas> oListPeliculas = new List<Peliculas>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Peliculas WHERE id = @Id; ", oConexion);
                cmd.Parameters.AddWithValue("@Id", cPeliculas.Id);

                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListPeliculas.Add(new Peliculas()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                anio = Convert.ToDateTime(dr["anio"])
                            }); ;
                        }
                    }
                    return oListPeliculas;
                }
                catch (Exception ex)
                {

                    return oListPeliculas;
                }
            }
        }
    }
}
