using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Listados
{
    public static class ListadoCoches
    {
        /// <summary>
        /// Funcion que recoge el listado de todos los coches en la "BBDD" y la devuelve
        /// </summary>
        /// <returns>Listado de coches</returns>
        public static List<clsCoche> ListadoCompletoCoches()
        {
            List<clsCoche> listado = new List<clsCoche>
            {
                new clsCoche (1,1,"Focus",25000),
                new clsCoche (2,1,"Kuga", 35000),
                new clsCoche (3,1,"Puma", 37000),
                new clsCoche (4,2,"Akana", 28000),
                new clsCoche (5,2,"Megane", 20000),
                new clsCoche (6,3,"C3", 14000),
                new clsCoche (7,3,"C4", 20000),
                new clsCoche (8,3,"C5",27000)
            };
            return listado;
        }
    }
}
