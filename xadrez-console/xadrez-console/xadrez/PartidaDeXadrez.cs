using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tabuleiro = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
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

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            turno++;
            MudaJogador();
        }

        private void MudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        public void ValidarPosicaoDeOrigem(Posicao origem)
        {
            if(tabuleiro.Peca(origem) == null)
            {
                throw new TabuleiroException("Não existe peca na posicao de origem escolhida.");
            }

            if(jogadorAtual != tabuleiro.Peca(origem).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua.");
            }

            if (!tabuleiro.Peca(origem).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possiveis para a peça de origem escolhida.");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tabuleiro.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida.");
            }
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
