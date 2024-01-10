using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class clsMarcas
    {

        #region atributos
        private int id;
        private string nombre;
        #endregion

        #region constructores
        public clsMarcas()
        {

        }

        public clsMarcas(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        #endregion

        #region propiedades
        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        #endregion
    }
}
