using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class clsModelos
    {

        private int id;
        private string nombre;
        private int idMarca;
        private double precio;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int IdMarca { get => idMarca; set => idMarca = value; }
        public double Precio { get => precio; set => precio = value; }

        public clsModelos()
        {
            
        }

        public clsModelos(int id, string nombre, int idMarca, float precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.idMarca = idMarca;
            this.precio = precio;
        }
            
    }
}
