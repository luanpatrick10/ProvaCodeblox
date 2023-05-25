using ProvaCodeblox.Dominio.ObjetoDeValor;

namespace ProvaCodeblox.Servicos.DTOS
{
    public class NovoProdutoDTO
    {
        public string? Nome { get; set; }
        public decimal PrecoDeVenda { get; set; }
        public string? Descricao { get; set; }
        public int Quantidade { get; set; }
        public ModoDeProducaoAgricula? Tipo { get; set; }
    }
}
