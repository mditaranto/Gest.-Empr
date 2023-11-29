using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manejadoras
{
    public class BorrarPersona
    {

        public static int Borrar(int id)
        {
            int numeroFilasAfectadas = 0;

            SqlCommand miComando = new SqlCommand();

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try

            {

                Conexion miConexion = new Conexion();
                SqlConnection conection = miConexion.getConnection();

                miComando.CommandText = "DELETE FROM Personas WHERE ID=@id";

                miComando.Connection = conection;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return numeroFilasAfectadas;
        }

    }
}

