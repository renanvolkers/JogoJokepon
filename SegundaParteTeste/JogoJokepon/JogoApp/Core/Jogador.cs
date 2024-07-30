namespace JogoApp.Core
{
    public class Jogador
    {
        public string Nome { get; set; }    
        public Carta Carta { get; set; }

        public Jogador()
        {
            Nome = string.Empty;
            Carta = new Carta();
        }

    }
}
