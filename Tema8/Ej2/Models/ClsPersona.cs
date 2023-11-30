using System.ComponentModel.DataAnnotations;

namespace Tema9.Models
{
    public class ClsPersona
    {

        #region atributos
        private int id;
        private string nombre;
        private string apellidos;
        private int idDept;
        #endregion

        #region constructores
        public ClsPersona()
        {
            nombre = "";
        }

        public ClsPersona(string nombre, string apellidos, int idDept, int id)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.idDept = idDept;
            this.id = id;
        }
        #endregion

        #region propiedades

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [Required(ErrorMessage = "El campo apellidos es obligatorio")]
        [StringLength(10, ErrorMessage = "El campo apellidos no puede tener más de 10 caracteres")]
        public string Apellidos
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
        public string Direccion { get; set; }

        public string nombreCompleto
        {
            get { return $"Su nombre completo es: {nombre} {apellidos}"; }
        }

        public string FuncionNombreCompleto()
        {
            return $"Su nombre completo es: {nombre} {apellidos}";
        }
        #endregion

    }

}

