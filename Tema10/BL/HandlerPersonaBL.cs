using DAL.Manejadoras;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class HandlerPersonaBL
    {
        /// <summary>
        /// Funcion que llama a la DAL y devuelve el numero de filas afectadas 
        /// al borrar una persona que recibe por id y aplica las normas de negocio
        /// Post: La salida sera 0: No se ha encontrado la persona, 1: Se ha borrado correctamente, -1: Error en la BL
        /// </summary>
        /// <param name="id">Id de la persona</param>
        /// <returns>Devuelve el numero de filas afectadas</returns>
        public static int BorrarPersonaBL(int id)
        {
            int numeroFilasAfectadas = 0;
            DateTime fechaActual = DateTime.Now;
            //Si el dia de la semana es miercoles no se puede borrar
            if (fechaActual.DayOfWeek == DayOfWeek.Thursday )
            {
                numeroFilasAfectadas = -1;
            } else
            {
                numeroFilasAfectadas = BorrarPersona.Borrar(id);
                
            }
            return numeroFilasAfectadas;

        }
    }


}
