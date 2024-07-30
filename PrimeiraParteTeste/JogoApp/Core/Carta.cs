namespace JogoApp.Core
{
    public class Carta
    {
        public string Nome { get; set; }
        public List<string> CartaInferior { get; set; }
        public Carta()
        {
            Nome = string.Empty;
            CartaInferior = new List<string>();
        }
    }

}
