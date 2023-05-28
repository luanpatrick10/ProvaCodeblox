using ProvaCodeblox.Dominio.Entidades;

namespace ProvaCodeblox.Dominio.Repositoiros
{
    public interface IProdutoRepositorio : ICrudRepositorio<Produto>
    {
        Task<Produto> ObterProdutoPorNome(string nome);
    }
}
