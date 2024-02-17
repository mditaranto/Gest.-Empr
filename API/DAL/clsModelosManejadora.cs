using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsModelosManejadora
    {

        private static clsConexion conexion = new clsConexion();

        public static List<clsModelos> ListadoCompletoModelos()
        {
            List<clsModelos> listado = new List<clsModelos>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsModelos oModelos;

            try

            {

                SqlConnection conexcionConBDD = conexion.getConnection();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)

                miComando.CommandText = "SELECT * FROM modelos";

                miComando.Connection = conexcionConBDD;

                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector

                if (miLector.HasRows)

                {

                    while (miLector.Read())

                    {

                        oModelos = new clsModelos();

                        oModelos.Id = (int)miLector["id"];

                        oModelos.IdMarca = (int)miLector["idMarca"];

                        oModelos.Nombre = (string)miLector["nombre"];

                        oModelos.Precio = (double)miLector["precio"];

                        listado.Add(oModelos);

                    }

                }

                miLector.Close();

                conexcionConBDD.Close();

            }

            catch (SqlException exSql)

            {

                throw exSql;

            }

            return listado;
        }

        /// <summary>
        /// Funcion que edita una persona en la base de datos y devuelve el numero de filas afectadas
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns>numero de filas afectadas</returns>
        public static int EditarModelo(clsModelos modelo)
        {
            int numeroFilasAfectadas = 0;

            SqlCommand miComando = new SqlCommand();

            clsConexion conexion = new clsConexion();

            SqlConnection miConexion = new SqlConnection();

            miConexion.ConnectionString = conexion.getStringConnection();

            try
            {

                miConexion.Open();

                miComando.CommandText = "UPDATE modelos " +
                    "SET nombre = @nombre, idMarca = @idMarca, precio = @precio " +
                    "WHERE id=@id";
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = modelo.Id;
                miComando.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = modelo.Nombre;
                miComando.Parameters.Add("@idMarca", System.Data.SqlDbType.Int).Value = modelo.IdMarca;
                miComando.Parameters.Add("@precio", System.Data.SqlDbType.Float).Value = modelo.Precio;

                miComando.Connection = miConexion;
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

