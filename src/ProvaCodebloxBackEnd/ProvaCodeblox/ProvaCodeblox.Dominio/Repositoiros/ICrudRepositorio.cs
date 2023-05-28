namespace ProvaCodeblox.Dominio.Repositoiros
{
    public interface ICrudRepositorio<T>
    {
        Task<ICollection<T>> ObterTodos();
        Task<T> ObterPorId(int? id);

        Task Criar(T entidade);
        Task Atualizar(T entidade);
        Task Deletar(T entidade);
    }
}
