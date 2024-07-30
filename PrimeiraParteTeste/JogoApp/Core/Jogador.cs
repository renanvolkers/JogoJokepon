namespace JogoApp.Core
{
    public class Jogador
    {
        public string Name { get; set; }    
        public Carta Carta { get; set; }

        public Jogador()
        {
            Name = string.Empty;
            Carta = new Carta();
        }

    }
}
