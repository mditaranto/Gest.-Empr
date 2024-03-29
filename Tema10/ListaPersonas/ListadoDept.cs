﻿using Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ListadoDept
    {

        private static Conexion miConexion = new Conexion();

        /// <summary>
        /// Funcion que devuelve un listado de personas obtenido de la base de datos
        /// </summary>
        /// <returns>Lista de personas</returns>
        public static List<ClsDepartamentos> ListadoCompletoDept()
        {

            List<ClsDepartamentos> listadoDEpt = new List<ClsDepartamentos>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsDepartamentos oDept;

            try

            {

                SqlConnection conexcionConBDD = miConexion.getConnection();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)

                miComando.CommandText = "SELECT * FROM Departamentos";

                miComando.Connection = conexcionConBDD;

                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector

                if (miLector.HasRows)

                {

                    while (miLector.Read())

                    {

                        oDept = new ClsDepartamentos();

                        oDept.Id = (int)miLector["ID"];

                        oDept.Nombre = (string)miLector["Nombre"];

                        listadoDEpt.Add(oDept);

                    }

                }

                miLector.Close();

                miConexion.closeConnection(ref conexcionConBDD);

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return listadoDEpt;
        }

        public static int crearDept(ClsDepartamentos dept)
        {
            int numeroFilasAfectadas = 0;

            SqlCommand miComando = new SqlCommand();

            Conexion conexion = new Conexion();

            SqlConnection miConexion = new SqlConnection();

            miConexion.ConnectionString = conexion.getStringConnection();


            try
            {
                miConexion.Open();

                miComando.CommandText = "INSERT INTO Departamentos (Nombre) " +
                    "VALUES (@Nombre)";
                miComando.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = dept.Nombre;

                miComando.Connection = miConexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return numeroFilasAfectadas;
        }

        public static int BorrarDept(int id)
        {
            int numeroFilasAfectadas = 0;

            SqlCommand miComando = new SqlCommand();

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try

            {

                Conexion miConexion = new Conexion();
                SqlConnection conection = miConexion.getConnection();

                miComando.CommandText = "DELETE FROM Departamentos WHERE ID=@id";

                miComando.Connection = conection;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return numeroFilasAfectadas;
        }

        public static int EditarDept(ClsDepartamentos dept)
        {
            int numeroFilasAfectadas = 0;

            SqlCommand miComando = new SqlCommand();

            Conexion conexion = new Conexion();

            SqlConnection miConexion = new SqlConnection();

            miConexion.ConnectionString = conexion.getStringConnection();

            try

            {


                miConexion.Open();

                miComando.CommandText = "UPDATE Departamentos " +
                    "SET Nombre = @Nombre " +
                    "WHERE ID=@id";
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = dept.Id;
                miComando.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = dept.Nombre;

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
