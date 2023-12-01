using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL.Manejadoras
{
    public static class EditarPersona
    {
        /// <summary>
        /// Funcion que edita una persona en la base de datos y devuelve el numero de filas afectadas
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>numero de filas afectadas</returns>
        public static int Editar(ClsPersona persona)
        {
            int numeroFilasAfectadas = 0;

            SqlCommand miComando = new SqlCommand();

            Conexion conexion = new Conexion();

            SqlConnection miConexion = new SqlConnection();

            miConexion.ConnectionString = conexion.getStringConnection();


            try

            {

               
             miConexion.Open();

                miComando.CommandText = "UPDATE Personas " +
                    "SET Nombre = @Nombre, apellidos = @Apellido, Telefono = @Telefono, Direccion = @Direccion, Foto = @Foto, FechaNacimiento = @FechaNacimiento, IDDepartamento = @IdDepartamento " +
                    "WHERE ID=@id";
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.Id;
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