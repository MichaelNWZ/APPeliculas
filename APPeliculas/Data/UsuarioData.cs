using APPeliculas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APPeliculas.Data
{
    public class UsuarioData
    {
        public static bool Obtener(Usuarios cUsuarios)
        {
            
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Usuarios WHERE Usuario = @Usuario and Clave = @Clave ; ", oConexion);
                

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
