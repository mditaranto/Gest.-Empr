using Mandalorian.DAL;

namespace Mandalorian.Models.ViewModel
{
    public class ListaMisionesConMision : Misiones
    {

        private List<Misiones> listaDeMisiones = ListaMisiones.listaDeMisiones();

        private Misiones misionElegida;
        public ListaMisionesConMision()
        {
           
        }

        public Misiones MisionElegida
        {
            get { return misionElegida; }
            set { misionElegida = value; }
        }

        public List<Misiones> ListaDeMisiones
        {
            get { return listaDeMisiones; }
        }

    }
}
