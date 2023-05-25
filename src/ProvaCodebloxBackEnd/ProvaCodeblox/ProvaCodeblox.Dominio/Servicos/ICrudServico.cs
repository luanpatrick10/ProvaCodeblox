namespace ProvaCodeblox.Dominio.Servicos
{
    public interface ICrudServico<T>
    {
        Task<ICollection<T>> ObterTodos();
        Task<T> ObterPorId(int? id);

        Task<T> Criar(T entidade);
        Task<T> Atualizar(T entidade);
        Task Deletar(int id);
    }
}
