
namespace tabuleiro
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Cor cor, Tabuleiro tabuleiro)
        {
            Posicao = null;
            Cor = cor;
            this.qteMovimentos = 0;
            this.tabuleiro = tabuleiro;
        }

        public void IncrementarQteMovimentos()
        {
            qteMovimentos++;
        }
    }
}
