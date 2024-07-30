namespace JogoApp.Core
{
    public class GerenciarJogo
    {
        public List<Jogador> Empatados { get; set; }
        public List<Jogador> Derrotados { get; set; }
        public List<Jogador> Jogadores { get; set; }
        public bool FinalizarJogo { get; set; } = false;

        private Jokenpo Joken { get; set; }


        public Jogador? Vencedor { get; set; }

        public GerenciarJogo()
        {
            Derrotados = new List<Jogador>();
            Empatados = new List<Jogador>();
            Jogadores = new List<Jogador>();
            Joken = new Jokenpo();
        }

        public void Inicializar()
        {

            Carta carta = new Carta();
            int quantidadeJogadores;

            try
            {
                Console.WriteLine(Const._entradaQuantidadeMsg);
                string quantidadeJogadoresInput = Console.ReadLine()!;
                quantidadeJogadores = Convert.ToInt16(quantidadeJogadoresInput);

                if (quantidadeJogadores >= Const._maxQuantidadeJogadores)
                {
                    Console.WriteLine(Const._quantidadeMaximaJogadores + Const._maxQuantidadeJogadores);
                    Inicializar();
                }

                for (int i = 0; i < quantidadeJogadores && !FinalizarJogo; i++)
                {
                        Console.WriteLine(Const._nomeMsg + i);
                        string nome = Console.ReadLine() ?? string.Empty;
                        if (nome.Count() >= Const._maxQuantidadeNome)
                        {
                            Console.WriteLine(Const._quantidadeMaximaNome + Const._maxQuantidadeNome);

                            i--;
                            continue;
                        }
                        carta = EscolherOpcao();
                        var jogador = new Jogador { Nome = nome, Carta = carta };

                        Jogadores.Add(jogador);
                  
                }
            }
            catch (Exception)
            {
                Console.WriteLine(Const._quantidadeInvalidaMsg);

                throw;
            }
        }

        public void ReiniciarJogadores()
        {
            Carta carta = new Carta();
            Jogadores.Clear();
            Jogadores.AddRange(Empatados);

            if (Empatados.Count > Const._unicoJogador || 
                (Jogadores.Count == Derrotados.Count 
                && Jogadores.Count != Const._nenhumJogador 
                && Jogadores.Count != Const._unicoJogador))
            {

                Jogadores.ForEach(jogador =>
                {
                    Console.WriteLine(Environment.NewLine);

                    Console.WriteLine(Const._escolheComputador + jogador.Nome);

                    carta = EscolherOpcao();
                    jogador.Carta = carta;
                });
                Derrotados.Clear();
                Empatados.Clear();

            }


        }

        private void GerenciarRodada(List<Jogador> jogadores)
        {
            jogadores.ForEach(jogador =>
            {
                Derrotados.AddRange(jogadores.Where(derrotado => jogador.Carta.CartasInferiores.Contains(derrotado.Carta.Nome))
                                             .ToList()
                                   );
            });
            Derrotados = Derrotados.DistinctBy(x => x.Nome)
                                   .ToList();

            Empatados = jogadores.Where(x => !Derrotados
                                 .Contains(x))
                                 .ToList();
            ExisteVencedor();
        }
        public void ConfigurarRodada()
        {
            if (Jogadores.Count == Const._unicoJogador)
            {
                Random randon = new Random();
                var numeroCarta = randon.Next(Joken.PadraoCartas.Count);
                var cartaAleatoria = Joken.PadraoCartas.Skip(numeroCarta)
                                                       .FirstOrDefault(new Carta());
                Jogador computador = new Jogador { Nome = Const._computador, Carta = cartaAleatoria };
                Jogadores.Add(computador);
            }

            GerenciarRodada(Jogadores);
        }

        public bool OpcaoCartaExiste(int index)
        {
            return Joken.PadraoCartas.Where((carta, indexP) => indexP == index)
                                     .Any();
        }
        public void ExisteVencedor()
        {
            if (Empatados.Count == Const._unicoJogador)
            {
                Vencedor = Empatados.FirstOrDefault();
                FinalizarJogo = true;
            }
        }

        public Carta EscolherOpcao()
        {
            int opcaoEscolha = int.MinValue;

            try
            {

                string opcoes = string.Join(Environment.NewLine, Joken.PadraoCartas.Select((carta, index) => $"[{index}]-" + carta.Nome));
                var mensagemOpcoes = $"Escolha o numero da opcao:{Environment.NewLine} {opcoes}{Environment.NewLine}[9] para SAIR";
                Console.WriteLine(mensagemOpcoes.Trim());
                string opcoesInput = Console.ReadLine()!;
                opcaoEscolha = Convert.ToInt16(opcoesInput);

                if (!OpcaoCartaExiste(opcaoEscolha) && opcoesInput != Const._opcaoTerminar)
                {
                    Console.WriteLine(Const._escolhaInvalida);
                }
                if (opcoesInput == Const._opcaoTerminar)
                {
                    FinalizarJogo = true;
                }
            }
            catch (Exception)
            {

                EscolherOpcao();
            }
            return Joken.PadraoCartas.Where((carta, indexP) => indexP == opcaoEscolha)
                                     .FirstOrDefault(new Carta());

        }
    }
}
