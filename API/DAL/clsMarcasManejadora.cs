using Microsoft.Data.SqlClient;
using Entidades;

namespace DAL
{
    public class clsMarcasManejadora
    {
        private static clsConexion conexion = new clsConexion();

        public static List<clsMarcas> ListadoCompletoMarcas()
        {
            List<clsMarcas> listado = new List<clsMarcas>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsMarcas oMarca;

            try

            {

                SqlConnection conexcionConBDD = conexion.getConnection();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)

                miComando.CommandText = "SELECT * FROM marcas";

                miComando.Connection = conexcionConBDD;

                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector

                if (miLector.HasRows)

                {

                    while (miLector.Read())

                    {

                        oMarca = new clsMarcas();

                        oMarca.Id = (int)miLector["ID"];

                        oMarca.Nombre = (string)miLector["Nombre"];

                        listado.Add(oMarca);

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
    }
    
}
