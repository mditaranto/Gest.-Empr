using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class ListadoPersonasBl
    {
        /// <summary>
        /// Funcion que devuelve un listado de personas obtenido de la DAL y 
        /// aplicando las reglas de negocio
        /// </summary>
        /// <returns>Lista con personas</returns>
        public static List<ClsPersona> ListadoCompletoPersonasBL()
        {

            return ListaPersonas.ListadoCompletoPersonas();
        }

        public static ClsPersona FindByIDBL(int id)
        {
            return ListaPersonas.FindByID(id);
        }

    }
}
