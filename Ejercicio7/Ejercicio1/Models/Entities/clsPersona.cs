namespace Ejercicio1.Models.Entities
{
    public class clsPersona
    {
        #region atributos
        private string nombre;
        private string apellido;
        #endregion

        #region constructores
        public clsPersona()
        {
            this.nombre = "";
            this.apellido = "";
        }

        public clsPersona(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }
        #endregion

        #region propiedades
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public String Direccion { get; set; }

        public String NombreCompleto
        {
            get { return $"{nombre} {apellido}"; }
        }

        #endregion
    }
}
