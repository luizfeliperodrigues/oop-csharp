using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        private bool PodeMover(Posicao posicao)
        {
            Peca p = tabuleiro.Peca(posicao);
            return p == null || p.Cor != this.Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tabuleiro.Linhas, tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if(tabuleiro.Peca(pos) != null && tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha -= 1;
            }

            //direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.Peca(pos) != null && tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna += 1;
            }

            //abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.Peca(pos) != null && tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha += 1;
            }

            //esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (tabuleiro.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tabuleiro.Peca(pos) != null && tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna -= 1;
            }

            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
