using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public static class ListaPersonas
    {

        private static Conexion miConexion = new Conexion();

        public static List<ClsPersona> ListadoCompletoPersonas()
        {

            List<ClsPersona> listadoPersonas = new List<ClsPersona>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsPersona oPersona;

            try

            {

                SqlConnection conexcionConBDD = miConexion.getConnection();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)

                miComando.CommandText = "SELECT * FROM personas";

                miComando.Connection = conexcionConBDD;

                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector

                if (miLector.HasRows)

                {

                    while (miLector.Read())

                    {

                        oPersona = new ClsPersona();

                        oPersona.Id = (int)miLector["ID"];

                        oPersona.Nombre = (string)miLector["Nombre"];

                        oPersona.Apellido = (string)miLector["Apellidos"];
                    
                        //Si sospechamos que el campo puede ser Null en la BBDD

                        if (miLector["FechaNacimiento"] != System.DBNull.Value)

                        { oPersona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"]; }

                        oPersona.Direccion = (string)miLector["Direccion"];

                        oPersona.Telefono = (string)miLector["Telefono"];

                        listadoPersonas.Add(oPersona);

                    }

                }

                miLector.Close();

                conexcionConBDD.Close();

            }

            catch (SqlException exSql)

            {

                throw exSql;

            }

            return listadoPersonas;
        }

        public static ClsPersona FindByID(int id)
        {
            SqlConnection conexionConBDD = miConexion.getConnection();
            SqlDataReader miLector;

            ClsPersona oPersona;

            try
            {
                SqlCommand miComando = new SqlCommand();

                miComando.CommandText = "SELECT * FROM personas WHERE ID = @id";
                miComando.Connection = conexionConBDD;
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    miLector.Read();

                    oPersona = new ClsPersona();

                    oPersona.Id = (int)miLector["ID"];
                    oPersona.Nombre = (string)miLector["Nombre"];
                    oPersona.Apellido = (string)miLector["Apellidos"];

                    if (miLector["FechaNacimiento"] != System.DBNull.Value)
                    { oPersona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"]; }

                    oPersona.Direccion = (string)miLector["Direccion"];
                    oPersona.Telefono = (string)miLector["Telefono"];

                    miLector.Close();
                    conexionConBDD.Close();

                }
                else
                {
                    miLector.Close();
                    conexionConBDD.Close();

                    return null;
                }
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return oPersona;
        }

    }
}