using UD7Ejercicios.Models.DAL;
using UD7Ejercicios.Models.Entities;

namespace UD7Ejercicios.Models.ViewModel
{
    public class clsEditarVM: clsPersona
    {
        public List<clsDepartamento> listadoDepartamentosVM { get; }

        public clsEditarVM()
        {
            listadoDepartamentosVM = ListaDepartamentos.listadoCompletoDepartamentos();
            this.Nombre = "Yeray";
            this.Apellido= "Jimenez";
            this.IdDepartamento = 3;
            this.Id = 1;

        }

    }
}
