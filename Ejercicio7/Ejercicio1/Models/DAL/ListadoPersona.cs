using Ejercicio1.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1.Models.DAL
{
    public static class ListadoPersona 
    {
        /// <summary>
        ///  Funcion que devuelve un listado de personas
        ///  Precondición: ninguna
        ///  Posrcondición: ninguna
        /// </summary>
        /// <returns></returns>
        public static List<clsPersona> listadoCompletoPersonas() {

            List<clsPersona> listaPersona = new List<clsPersona>
            {
                new clsPersona("Juanma", "Sanchez"),
                new clsPersona("Fernando", "Miguel"),
                new clsPersona("Pablo", "Gonzalez"),
                new clsPersona("Yeray", "Jimenez"),
                new clsPersona("Matti", "Ditaranto"),
            };

            return listaPersona;

        }

    }
}
