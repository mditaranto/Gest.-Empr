using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manejadoras
{
    public static class EditarPersona
    {

        public static int Editar(ClsPersona persona)
        {
            int numeroFilasAfectadas = 0;

            SqlCommand miComando = new SqlCommand();

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.Id;
            miComando.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            miComando.Parameters.Add("@Apellido", System.Data.SqlDbType.VarChar).Value = persona.Apellido;
            miComando.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FechaNacimiento;
            miComando.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
            miComando.Parameters.Add("@Telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
            miComando.Parameters.Add("@Foto", System.Data.SqlDbType.VarChar).Value = persona.Foto;
            miComando.Parameters.Add("@IdDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;

            try

            {

                Conexion miConexion = new Conexion();
                SqlConnection conection = miConexion.getConnection();

                miComando.CommandText = "UPDATE Personas " +
                    "SET Nombre = @Nombre, apellidos = @Apellido, Telefono = @Telefono, Direccion = @Direccion, Foto = @Foto, FechaNacimiento = @FechaNacimiento, IDDepartamento = @IdDepartamento " +
                    "WHERE IDPersona=@id";

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