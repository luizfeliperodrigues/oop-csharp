﻿using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tabuleiro = new Tabuleiro(8, 8);

            try
            {
                tabuleiro.ColocarPeca(new Torre(Cor.Preta, tabuleiro), new Posicao(0, 0));
                tabuleiro.ColocarPeca(new Torre(Cor.Preta, tabuleiro), new Posicao(1, 3));
                tabuleiro.ColocarPeca(new Rei(Cor.Preta, tabuleiro), new Posicao(1, 4));

                tabuleiro.ColocarPeca(new Rei(Cor.Branca, tabuleiro), new Posicao(1, 6));
                tabuleiro.ColocarPeca(new Rei(Cor.Branca, tabuleiro), new Posicao(4, 2));
                tabuleiro.ColocarPeca(new Rei(Cor.Branca, tabuleiro), new Posicao(2, 5));

                Tela.ImprimirTabuleiro(tabuleiro);
            }

            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
