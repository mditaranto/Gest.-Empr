using UD7Ejercicios.Models.Entities;

namespace UD7Ejercicios.Models.DAL
{
    public static class ListaPersonas
    {
        /// <summary>
        /// Función que devuelve un listado de personas
        /// Precondición : Ninguna
        /// Postcondición : Ninguna
        /// </summary>
        /// <returns>Lista de personas</returns>
        public static List<clsPersona> listadoCompletoPersonas(){ 
            List<clsPersona> listadoPersona = new List<clsPersona>() {
                new clsPersona("Yerai", "Jiménez", 1,1),
                new clsPersona("Juan", "García", 2,2),
                new clsPersona("Alex", "Rodríguez", 3,3),
                new clsPersona("Xavi", "Hernández", 4,4)
            
            };
            
            return listadoPersona;

        }
    }
}
