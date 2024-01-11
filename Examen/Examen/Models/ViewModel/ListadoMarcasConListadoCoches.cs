using BL.Listados;
using Entidades;

namespace Examen.Models.ViewModel
{
    public class ListadoMarcasConListadoCoches
    {
        private int idMarca = 0;
        private List<clsMarcas> listaDeMarcas = ListaMarcasBL.ListadoCompletoMarcasBL();
        private List<clsCoche> listaDeCochesElegida;
        private clsMarcas marcaElegida;

        public ListadoMarcasConListadoCoches()
        {
            
        }
        /// <summary>
        /// Constructor que recoge el id con el que dara valor a la marca elegida, con esta id se buscan los coches de la marca en la lista
        /// </summary>
        /// <param name="id"></param>
        public ListadoMarcasConListadoCoches(int id)
        {
            idMarca = id;
            marcaElegida = listaDeMarcas.FirstOrDefault(mar => mar.Id == id);
            List<clsCoche> listaDeCoches = ListadoCochesBL.ListadoCompletoCochesBl();
            listaDeCochesElegida = listaDeCoches.FindAll(coche => coche.IdMarca == id);
        }
        public List<clsMarcas> ListaDeMarcas
        {
            get { return listaDeMarcas; }
        }

        public clsMarcas MarcaElegida
        {
            get { return marcaElegida; }
        }

        public int IdMarca
        {
            get { return idMarca; }
            set { idMarca = value; }
        }

        public List<clsCoche> ListaDeCochesElegida
        {
            get { return listaDeCochesElegida; }
        }
    }
}
