namespace JogoApp.Core
{
    public class Jokenpo
    {
        public List<Carta> PadraoCartas { get; set; }
        public Jokenpo()
        {
            PadraoCartas = JogoPadrao();
        }

        public List<Carta> JogoPadrao()
        {
            return PadraoCartas = new List<Carta>
            {
                new Carta{ Nome = "papel", CartasInferiores = { "pedra", "spock" } } ,
                new Carta{ Nome="tesoura",CartasInferiores={"papel", "lizard" } },
                new Carta{ Nome="pedra",CartasInferiores={"tesoura","lizard" }},
                new Carta{ Nome="spock",CartasInferiores={"tesoura","pedra", }},
                new Carta{ Nome="lizard",CartasInferiores={ "spock", "papel", }}
            };
        }
    }
}
