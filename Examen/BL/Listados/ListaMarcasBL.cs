using DAL.Listados;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Listados
{
    public static class ListaMarcasBL
    {
        /// <summary>
        /// Funcion que llama a la DAL para recoger las marcas y devolverlas en una lista
        /// </summary>
        /// <returns>lista de marcas</returns>
        public static List<clsMarcas> ListadoCompletoMarcasBL()
        {
            return ListaMarcas.ListadoCompletoMarcas();
        }
    }
}
