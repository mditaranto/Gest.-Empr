using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manejadoras
{
    public class CrearPersona
    {
        /// <summary>
        /// Funcion que crea una persona en la base de datos y devuelve el numero de filas afectadas
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>Numero de filas afectadas</returns>
        public static int Crear(ClsPersona persona)
        {
            int numeroFilasAfectadas = 0;

            SqlCommand miComando = new SqlCommand();

            Conexion conexion = new Conexion();

            SqlConnection miConexion = new SqlConnection();

            miConexion.ConnectionString = conexion.getStringConnection();


            try
            {
                miConexion.Open();

                miComando.CommandText = "INSERT INTO Personas (Nombre, Apellidos, FechaNacimiento, Direccion, Telefono, Foto, IDDepartamento) " +
                    "VALUES (@Nombre, @Apellido, @FechaNacimiento, @Direccion, @Telefono, @Foto, @IdDepartamento)";
                miComando.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
                miComando.Parameters.Add("@Apellido", System.Data.SqlDbType.VarChar).Value = persona.Apellido;
                miComando.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FechaNacimiento;
                miComando.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
                miComando.Parameters.Add("@Telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
                miComando.Parameters.Add("@Foto", System.Data.SqlDbType.VarChar).Value = persona.Foto;
                miComando.Parameters.Add("@IdDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;

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
