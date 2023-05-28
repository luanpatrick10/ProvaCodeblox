using ProvaCodeblox.Dominio.Entidades;

namespace ProvaCodeblox.Dominio.Servicos
{
    public interface ICadastroDeProdutoServico : ICrudServico<Produto>
    {
        Task<Produto> ObterProdutoPorNome(string nome);
    }
}
