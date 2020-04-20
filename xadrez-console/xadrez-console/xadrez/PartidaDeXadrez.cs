using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public bool Xeque { get; private set; }
        public Peca vulneravelEnPassant { get; private set; }

        public PartidaDeXadrez()
        {
            tabuleiro = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            Xeque = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tabuleiro.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = tabuleiro.RetirarPeca(destino);
            tabuleiro.ColocarPeca(p, destino);
            if(pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tabuleiro.RetirarPeca(destino);
            p.DecrementarQteMovimentos();
            if(pecaCapturada != null)
            {
                tabuleiro.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            tabuleiro.ColocarPeca(p, origem);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(jogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque.");
            }

            if (EstaEmXeque(Adversaria(jogadorAtual)))
            {
                Xeque = true;
            }
            else{
                Xeque = false;
            }

            if (TesteXequemate(Adversaria(jogadorAtual)))
            {
                terminada = true;
            }
            else
            {
                turno++;
                MudaJogador();
            }
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
            if (!tabuleiro.Peca(origem).MovimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino inválida.");
            }
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach(Peca p in Capturadas)
            {
                if (p.Cor == cor)
                {
                    aux.Add(p);
                }
            }
            
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca p in Pecas)
            {
                if (p.Cor == cor)
                {
                    aux.Add(p);
                }
            }

            aux.ExceptWith(PecasCapturadas(cor));

            return aux;
        }

        public void ColocarPecas()
        {

            ColocarNovaPeca('a', 1, new Torre(tabuleiro, Cor.Branca));
            ColocarNovaPeca('b', 1, new Cavalo(tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 1, new Bispo(tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 1, new Dama(tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 1, new Rei(tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('f', 1, new Bispo(tabuleiro, Cor.Branca));
            ColocarNovaPeca('g', 1, new Cavalo(tabuleiro, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(tabuleiro, Cor.Branca));
            ColocarNovaPeca('a', 2, new Peao(tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('b', 2, new Peao(tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('c', 2, new Peao(tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('d', 2, new Peao(tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('e', 2, new Peao(tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('f', 2, new Peao(tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('g', 2, new Peao(tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('h', 2, new Peao(tabuleiro, Cor.Branca, this));

            ColocarNovaPeca('a', 8, new Torre(tabuleiro, Cor.Preta));
            ColocarNovaPeca('b', 8, new Cavalo(tabuleiro, Cor.Preta));
            ColocarNovaPeca('c', 8, new Bispo(tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 8, new Dama(tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 8, new Rei(tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('f', 8, new Bispo(tabuleiro, Cor.Preta));
            ColocarNovaPeca('g', 8, new Cavalo(tabuleiro, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(tabuleiro, Cor.Preta));
            ColocarNovaPeca('a', 7, new Peao(tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('b', 7, new Peao(tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('c', 7, new Peao(tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('d', 7, new Peao(tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('e', 7, new Peao(tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('f', 7, new Peao(tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('g', 7, new Peao(tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('h', 7, new Peao(tabuleiro, Cor.Preta, this));


            /*
            //Teste para xequemate
            ColocarNovaPeca('c', 1, new Torre(Cor.Branca, tabuleiro));
            ColocarNovaPeca('d', 1, new Rei(Cor.Branca, tabuleiro));
            ColocarNovaPeca('h', 7, new Torre(Cor.Branca, tabuleiro));

            ColocarNovaPeca('a', 8, new Rei(Cor.Preta, tabuleiro));
            ColocarNovaPeca('b', 8, new Torre(Cor.Preta, tabuleiro));
            */


            /*
            ColocarNovaPeca('c', 1, new Torre(Cor.Branca, tabuleiro));
            ColocarNovaPeca('c', 2, new Torre(Cor.Branca, tabuleiro));
            ColocarNovaPeca('d', 2, new Torre(Cor.Branca, tabuleiro));
            ColocarNovaPeca('e', 2, new Torre(Cor.Branca, tabuleiro));
            ColocarNovaPeca('e', 1, new Torre(Cor.Branca, tabuleiro));
            ColocarNovaPeca('d', 1, new Rei(Cor.Branca, tabuleiro));

            ColocarNovaPeca('c', 7, new Torre(Cor.Preta, tabuleiro));
            ColocarNovaPeca('c', 8, new Torre(Cor.Preta, tabuleiro));
            ColocarNovaPeca('d', 7, new Torre(Cor.Preta, tabuleiro));
            ColocarNovaPeca('e', 7, new Torre(Cor.Preta, tabuleiro));
            ColocarNovaPeca('e', 8, new Torre(Cor.Preta, tabuleiro));
            ColocarNovaPeca('d', 8, new Rei(Cor.Preta, tabuleiro));
            */
        }

        private Cor Adversaria(Cor cor)
        {
            if(cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca Rei(Cor cor)
        {
            foreach(Peca p in PecasEmJogo(cor))
            {
                if(p is Rei)
                {
                    return p;
                }
            }

            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca R = Rei(cor);

            if(R == null)
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro");
            }

            foreach(Peca p in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = p.MovimentosPossiveis();

                if(mat[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }

            }

            return false;
        }

        public bool TesteXequemate(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }
            
            foreach(Peca p in PecasEmJogo(cor))
            {
                bool[,] mat = p.MovimentosPossiveis();
                for (int i=0; i < tabuleiro.Linhas; i++)
                {
                    for(int j = 0; j < tabuleiro.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = p.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }

            }

            return true;
        }
    }
}
