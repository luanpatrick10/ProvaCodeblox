﻿namespace ProvaCodeblox.Dominio.Servicos
{
    public interface ICrudServico<T>
    {
        Task<ICollection<T>> ObterTodos();
        Task<T> ObterPorId(int? id);

        Task Criar(T entidade);
        Task Atualizar(T entidade);
        Task Deletar(int id);
    }
}
