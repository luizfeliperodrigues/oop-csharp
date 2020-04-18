using System;
using tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tela.ImprimirTabuleiro(new Tabuleiro(8, 8));
        }
    }
}
