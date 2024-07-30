
using JogoApp.Core;
const int maisUmJogador = 1;
Jokepon Joken = new Jokepon();

var JogadorCarta = Joken.PadraoCartas().FirstOrDefault(x => x.Nome == "Papel");

Jogador jogador = new Jogador { Name = "Renan", Carta = JogadorCarta };

List<Jogador> listaJogadores = new List<Jogador>();


var carta = Joken.PadraoCartas().FirstOrDefault(x=>x.Nome == "Tesoura");
Jogador computador = new Jogador { Name = "Computador", Carta = carta };
listaJogadores.Add(jogador);
listaJogadores.Add(computador);

List<Jogador> derrotados = new List<Jogador>();
List<Jogador> empatados = new List<Jogador>();

listaJogadores.ForEach(jogador => {
    derrotados.AddRange(listaJogadores.Where(derrotado => jogador.Carta.CartaInferior.Contains(derrotado.Carta.Nome)).ToList());
});
derrotados = derrotados.DistinctBy(x => x.Name).ToList();
empatados = listaJogadores.Where(x => !derrotados.Select(x => x).Contains(x)).ToList();
if (empatados.Count > maisUmJogador)
{
    Console.WriteLine("Empatado");
}
if (empatados.Count == 1)
{
    var jogadorVencedor = listaJogadores.Where(x => !derrotados.Contains(x)).FirstOrDefault(new Jogador());
    Console.WriteLine("Venceu " + jogadorVencedor.Name + " (" + jogadorVencedor.Carta.Nome + ")");
    var derrotado = derrotados.FirstOrDefault(new Jogador());
    Console.WriteLine("Derrotado " + derrotado.Name + " (" + derrotado.Carta.Nome + ")");
}

