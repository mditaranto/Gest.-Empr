using BL.Listados;
using Entidades;

namespace Examen.Models.ViewModel
{
    public class CocheConMarca
    {

        private clsCoche cocheElegido;
        private clsMarcas marcaDelCoche;

        public CocheConMarca(int id)
        {
            List<clsCoche> listaCoches = ListadoCochesBL.ListadoCompletoCochesBl();
            cocheElegido = listaCoches.FirstOrDefault(coche => coche.Id == id);
            marcaDelCoche = ListaMarcasBL.ListadoCompletoMarcasBL().FirstOrDefault(mar => mar.Id == cocheElegido.IdMarca);
        }

        public clsCoche CocheElegido
        {
            get { return cocheElegido; }
        }

        public clsMarcas MarcaDelCoche
        {
            get { return marcaDelCoche; }
        }
    }
}
