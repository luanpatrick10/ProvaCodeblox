using ProvaCodeblox.Dominio.ObjetosDeDominio;
using ProvaCodeblox.Dominio.Repositoiros;
using ProvaCodeblox.Dominio.Servicos;
using ProvaCodeblox.Servicos.Excecoes;

namespace ProvaCodeblox.Servicos.Servicos
{
    public abstract class ServicosDeCRUD<T> : ICrudServico<T> where T : Entidade
    {
        protected ICrudRepositorio<T> _repositorio;
        public ServicosDeCRUD(ICrudRepositorio<T> repositorio)
        {
            _repositorio = repositorio;
        }

        public virtual async Task Atualizar(T entidade)
        {
            await ValidaAlteracao(entidade);
            await _repositorio.Atualizar(entidade);
        }

        public virtual async Task Criar(T entidade)
        {
            await ValidarInclusao(entidade);
            await _repositorio.Criar(entidade);
        }

        public virtual async Task Deletar(int id)
        {
            await ValidarExclusao(id);
            T entidade = await ObterPorId(id);
            await _repositorio.Deletar(entidade);
        }

        public virtual async Task<T> ObterPorId(int? id)
        {
            try
            {
                T entidade = await _repositorio.ObterPorId(id);
                return entidade;
            }
            catch (InvalidOperationException ex)
            {
                throw new NaoEncontradoException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ICollection<T>> ObterTodos()
        {
            try
            {
                ICollection<T> entidades = await _repositorio.ObterTodos();
                ValidarSeConsultaNaoEstaVazia(entidades);
                return entidades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected async virtual Task ValidarInclusao(T entidade) { entidade.ValidarEntidade(); }
        protected async virtual Task ValidarExclusao(int id) { }
        protected async virtual Task ValidaAlteracao(T entidade) { entidade.ValidarEntidade(); }

        protected void ValidarSeConsultaNaoEstaNula(T entidade)
        {
            if (entidade == null)
                throw new NaoEncontradoException();
        }

        protected void ValidarSeConsultaNaoEstaVazia(IEnumerable<T> entidade)
        {
            if (entidade.Count() == 0)
                throw new SemDadosDisponiveisException();
        }
    }
}
