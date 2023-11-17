namespace Mandalorian.Models.ViewModels
{
    static public class ListaMisiones
    {
        static public List<Misiones> getListaMisiones()
        {
            return new List<Misiones>()
            {
                new Misiones(1, "Rescate de Baby Yoda", "Debes hacerte con Grogu y llevárselo a Luke SkyWalker para su entrenamiento.", 5000),
                new Misiones(2, "Recuperar armadura Beskar", "Tu armadura de Beskar ha sido robada. Debes encontrarla.", 2000),
                new Misiones(3, "Planeta Sorgon", "Debes llevar a un niño de vuelta a su planeta natal “Sorgon”.", 500),
                new Misiones(4, "Renacuajos", "Debes llevar a una Dama Rana y sus huevos de Tatooine a la " +
                "luna del estuario Trask, donde su esposo fertilizará los huevos.", 500)
            };
        }
    }
}
