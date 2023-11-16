namespace Tema8.Models
{
    public class ClsPersona
    {
        #region atributos
        private int id;
        private String nombre;
        private String apellidos;
        private int idDept;
        #endregion

        #region constructores
        public ClsPersona()
        {
            nombre = "";
        }

        public ClsPersona(String nombre, String apellidos, int idDept, int id)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.idDept = idDept;
            this.id = id;
        }
        #endregion

        #region propiedades
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public String Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        public int IdDept
        {
            get { return idDept; }
            set { idDept = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Direccion { get; set; }

        public String nombreCompleto
        {
            get { return $"Su nombre completo es: {nombre} {apellidos}"; }
        }

        public String FuncionNombreCompleto()
        {
            return $"Su nombre completo es: {nombre} {apellidos}";
        }
        #endregion
    }
}
