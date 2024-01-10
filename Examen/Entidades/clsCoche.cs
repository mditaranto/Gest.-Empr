using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class clsCoche
    {

        #region atributos
        private int id;
        private int idMarca;
        private string nombre;
        private long precio;
        #endregion

        #region constructores
        public clsCoche() { }

        public clsCoche(int id, int idMarca, string nombre, long precio)
        {
            this.id = id;
            this.idMarca = idMarca;
            this.nombre = nombre;
            this.precio = precio;
        }
        #endregion

        #region propiedades

        public int Id { get { return id; } }

        public int IdMarca 
        { 
            get { return idMarca; } 
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public long Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        #endregion

    }
}
