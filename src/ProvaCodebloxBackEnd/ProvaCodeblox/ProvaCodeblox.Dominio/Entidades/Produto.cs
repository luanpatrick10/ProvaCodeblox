using ProvaCodeblox.Dominio.ObjetoDeValor;
using ProvaCodeblox.Dominio.ObjetosDeDominio;

namespace ProvaCodeblox.Dominio.Entidades
{
    public class Produto : Entidade, IAggregateRoot
    {
        public string? Nome { get; private set; }
        public decimal PrecoDeVenda { get; private set; }
        public string? Descricao { get; private set; }
        public int Quantidade { get; private set; }
        public ModoDeProducaoAgricula? Tipo { get; private set; }

        public Produto() { }
        public Produto(string? nome, decimal precoDeVenda, string descricao, int quantidade, ModoDeProducaoAgricula? tipo)
        {
            Nome = nome;
            PrecoDeVenda = precoDeVenda;
            Descricao = descricao;
            Quantidade = quantidade;
            Tipo = tipo;
            ValidarEntidade();
        }
        public override void ValidarEntidade()
        {
            ValidacoesDeDominio.ValidarSeNaoEhVazioOuNulo(Nome, MensagensDeValidacoes.PropriedadeNulaOuVazio);
            ValidacoesDeDominio.ValidarSeMaiorOuIgualQue(PrecoDeVenda, 0, MensagensDeValidacoes.PropriedadeMenorQueValorMinimo(nameof(PrecoDeVenda)));
            ValidacoesDeDominio.ValidarSeNaoEhNulo(Tipo, MensagensDeValidacoes.PropriedadeNula(nameof(Tipo)));
        }
    }
}
