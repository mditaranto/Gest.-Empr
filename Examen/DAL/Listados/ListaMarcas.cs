using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Listados
{
    public static class ListaMarcas
    {
        /// <summary>
        /// Funcion que recoge todas las marcas de la "BBDD" y las devuelve en una lista
        /// </summary>
        /// <returns>lista de marcas</returns>
        public static List<clsMarcas> ListadoCompletoMarcas()
        {
            List<clsMarcas> listado = new List<clsMarcas>
            {
                new clsMarcas (1, "Ford"),
                new clsMarcas (2, "Renault"),
                new clsMarcas (3, "Citroen")
         
            };
            return listado;
        }
    }
}
