namespace Mandalorian.Models
{
    public class Misiones
    {
        #region atributos
        private int id;
        private string titulo;
        private string descripcion;
        private long recompensa;
        #endregion

        #region constructores
        public Misiones()
        {
            id = 0;
            titulo = string.Empty;
            descripcion = string.Empty;
            recompensa = 0;
        }

        public Misiones(int id, string titulo, string descripcion, int recompensa)
        {
            this.id = id;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.recompensa = recompensa;
        }

        #endregion

        #region propiedades

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public string Titulo
        {
            set { titulo = value; }
            get { return titulo; }

        }

        public string Descripcion
        {
            set { descripcion = value; }
            get { return descripcion; }
        }

        public long Recompensa
        { 
            get { return recompensa; } 
            set { recompensa = value; }
        }

        #endregion


    }
}
