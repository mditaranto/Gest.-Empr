using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public static class ListaPersonas
    {

        public static List<ClsPersona> ListadoCompletoPersonas()
        {
            SqlConnection miConexion = new SqlConnection();

            List<ClsPersona> listadoPersonas = new List<ClsPersona>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsPersona oPersona;

            miConexion.ConnectionString
            = ("server=107-08\\SQLEXPRESS;database=Persona;uid=prueba;pwd=123;trustServerCertificate=true");

            try

            {

                miConexion.Open();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)

                miComando.CommandText = "SELECT * FROM personas";

                miComando.Connection = miConexion;

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

                miConexion.Close();

            }

            catch (SqlException exSql)

            {

                throw exSql;

            }

            return listadoPersonas;
        }

    }
}