using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        private int turno;
        private Cor jorgadorAtual;
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tabuleiro = new Tabuleiro(8, 8);
            turno = 1;
            jorgadorAtual = Cor.Branca;
            terminada = false;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tabuleiro.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = tabuleiro.RetirarPeca(destino);
            tabuleiro.ColocarPeca(p, destino);
        }

        public void ColocarPecas()
        {
            tabuleiro.ColocarPeca(new Torre(Cor.Branca, tabuleiro), new PosicaoXadrez('c', 1).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Branca, tabuleiro), new PosicaoXadrez('c', 2).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Branca, tabuleiro), new PosicaoXadrez('d', 2).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Branca, tabuleiro), new PosicaoXadrez('e', 2).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Branca, tabuleiro), new PosicaoXadrez('e', 1).ToPosicao());
            tabuleiro.ColocarPeca(new Rei(Cor.Branca, tabuleiro), new PosicaoXadrez('d', 1).ToPosicao());

            tabuleiro.ColocarPeca(new Torre(Cor.Preta, tabuleiro), new PosicaoXadrez('c', 7).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Preta, tabuleiro), new PosicaoXadrez('c', 8).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Preta, tabuleiro), new PosicaoXadrez('d', 7).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Preta, tabuleiro), new PosicaoXadrez('e', 7).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Preta, tabuleiro), new PosicaoXadrez('e', 8).ToPosicao());
            tabuleiro.ColocarPeca(new Rei(Cor.Preta, tabuleiro), new PosicaoXadrez('d', 8).ToPosicao());
        }
    }
}
