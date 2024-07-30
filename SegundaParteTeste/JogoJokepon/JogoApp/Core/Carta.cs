namespace JogoApp.Core
{
    public class Carta
    {
        public string Nome { get; set; }
        public List<string> CartasInferiores { get; set; }     
        public Carta() {
            Nome = string.Empty;
            CartasInferiores = new List<string>();
        }
        public void AddAdversario(string jogador)
        {
            CartasInferiores.Add(jogador);
        }
    }
}
