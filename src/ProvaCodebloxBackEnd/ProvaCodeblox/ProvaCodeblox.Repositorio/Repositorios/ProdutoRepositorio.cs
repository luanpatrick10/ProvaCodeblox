using Microsoft.EntityFrameworkCore;
using ProvaCodeblox.Dominio.Entidades;
using ProvaCodeblox.Dominio.Repositoiros;
using ProvaCodeblox.Repositorio.Contexto;

namespace ProvaCodeblox.Repositorio.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private ApplicationDbContext _applicationDbContext;
        public ProdutoRepositorio(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task Atualizar(Produto produto)
        {
            _applicationDbContext.Update(produto);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Criar(Produto produto)
        {

            _applicationDbContext.Podutos.Add(produto);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Deletar(Produto produto)
        {
            _applicationDbContext.Remove(produto);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<Produto> ObterPorId(int? id)
        {
            return await _applicationDbContext.Podutos.FirstAsync(produto => produto.Id == id);
        }

        public async Task<Produto> ObterProdutoPorNome(string nome)
        {
            return await _applicationDbContext.Podutos.FirstOrDefaultAsync(produto => produto.Nome == nome);
        }

        public async Task<ICollection<Produto>> ObterTodos()
        {
            return await _applicationDbContext.Podutos.ToListAsync();
        }
    }
}
