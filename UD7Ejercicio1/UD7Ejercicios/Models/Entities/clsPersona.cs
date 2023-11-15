
namespace UD7Ejercicios.Models.Entities
{
    public class clsPersona
    {
        #region atributos
        private int id;
        private string nombre;
        private string apellido;
        private int idDepartamento;
        #endregion

        #region constructores
        public clsPersona() {
            id = 0;
            nombre = "";
            apellido = "";
            idDepartamento = 0;
        }

        public clsPersona (string nombre, string apellido, int idDepartamento, int id) {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.idDepartamento = idDepartamento;
        }
        #endregion

        #region propiedades
            public String Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Apellido {
            get { return apellido; }
            set { apellido = value; }
        }

        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }

        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String NombreCompleto {
            get { return $"{nombre} {apellido}"; }
        }

        #endregion

    }
}
