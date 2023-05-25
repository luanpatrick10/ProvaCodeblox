using ProvaCodeblox.Dominio.Entidades;

namespace ProvaCodeblox.Dominio.Repositoiros
{
    public interface IProdutoRepositorio
    {
        Task<ICollection<Produto>> ObterProdutos();
        Task<Produto> ObtePorId(int? id);

        Task Criar(Produto produto);
        Task Atualizar(Produto produto);
        Task Deletar(Produto produto);
    }
}
