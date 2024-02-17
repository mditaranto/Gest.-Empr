namespace Entidades
{
    public class clsMarcas
    {
        private int id;
        private string nombre;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public clsMarcas()
        {
           
        }

        public clsMarcas(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        } 

    }
}
