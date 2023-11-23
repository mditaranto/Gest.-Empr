using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClsDepartamentos
    {
        private int id;
        private string nombre;

        public ClsDepartamentos()
        {
        }

        public ClsDepartamentos(int id, string nombre, string localidad)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value.Trim(); }
    }
}
