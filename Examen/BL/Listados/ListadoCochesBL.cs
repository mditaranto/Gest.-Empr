using DAL.Listados;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Listados
{
    public static class ListadoCochesBL
    {
        /// <summary>
        /// Funcion que llama a la DAL para recoger los coches y devolverlo en una lista
        /// </summary>
        /// <returns>lista de coches</returns>
        public static List<clsCoche> ListadoCompletoCochesBl()
        {
            return ListadoCoches.ListadoCompletoCoches();
        }
    }
}
