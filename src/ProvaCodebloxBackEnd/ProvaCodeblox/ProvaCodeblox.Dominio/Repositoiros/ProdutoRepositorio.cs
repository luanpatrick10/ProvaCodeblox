using ProvaCodeblox.Dominio.Entidades;

namespace ProvaCodeblox.Dominio.Repositoiros
{
    public interface ProdutoRepositorio
    {
        Task<ICollection<Produto>> ObterProdutos();
        Task<Produto> ObtePorId(int? id);

        Task<Produto> Criar(Produto produto);
        Task<Produto> Atualizar(Produto produto);
        Task<Produto> Deletar(Produto produto);
    }
}
