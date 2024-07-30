
using JogoApp.Core;
var gerenciarJogo = new GerenciarJogo();


gerenciarJogo.Inicializar();
while (!gerenciarJogo.FinalizarJogo)
{

    gerenciarJogo.ConfigurarRodada();


    if (gerenciarJogo.Empatados.Count > Const._vencendor)
    {
        Console.WriteLine("Empatados " + string.Join(",", gerenciarJogo.Empatados.Select(x => x.Nome + "(" + x.Carta.Nome + ")")));
        Console.WriteLine("O Derrotado(s) " + string.Join(",", gerenciarJogo.Derrotados.Select(x => x.Nome + "(" + x.Carta.Nome + ")"+Environment.NewLine)));

        gerenciarJogo.ReiniciarJogadores();
    }
    else
    {
        Console.WriteLine("O Vencedor: " + gerenciarJogo.Vencedor?.Nome+"("+gerenciarJogo.Vencedor?.Carta.Nome+")");
        Console.WriteLine("O(s) Derrotado(s) " + string.Join(",", gerenciarJogo.Derrotados.Select(x=>x.Nome + "(" + x.Carta.Nome+")")) + Environment.NewLine);
        gerenciarJogo.ReiniciarJogadores();

    }


}
