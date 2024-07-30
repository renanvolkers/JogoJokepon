namespace JogoApp.Core
{
    public class Jokepon
    {
        public List<Carta> CartasPadrao { get; set; }
        public Jokepon() {
            CartasPadrao = PadraoCartas();
        }
        public List<Carta> PadraoCartas()
        {
            CartasPadrao = new List<Carta>();
            CartasPadrao.Add(new Carta { Nome = "Pedra",CartaInferior = { "Tesoura"} });
            CartasPadrao.Add(new Carta { Nome = "Tesoura", CartaInferior = { "Papel" } });
            CartasPadrao.Add(new Carta { Nome = "Papel", CartaInferior = { "Pedra" } });
            return CartasPadrao;
        }
    }
}
