using ProvaCodeblox.Dominio.Entidades;
using ProvaCodeblox.Dominio.Repositoiros;
using ProvaCodeblox.Dominio.Servicos;

namespace ProvaCodeblox.Servicos.Servicos
{
    public class CadastroDeProdutoServico : ICadastroDeProdutoServico
    {
        private IProdutoRepositorio _repositorioDeProduto;
        public CadastroDeProdutoServico(IProdutoRepositorio repositorioDeProduto)
        {
            _repositorioDeProduto = repositorioDeProduto;
        }

        public async Task<Produto> Atualizar(Produto produto)
        {
            produto.ValidarEntidade();
            await _repositorioDeProduto.Atualizar(produto);
            return produto;

        }

        public async Task<Produto> Criar(Produto produto)
        {
            produto.ValidarEntidade();
            await _repositorioDeProduto.Criar(produto);
            return produto;
        }

        public async Task Deletar(int id)
        {
            Produto produto = await _repositorioDeProduto.ObtePorId(id);
            await _repositorioDeProduto.Deletar(produto);
        }

        public async Task<Produto> ObterPorId(int? id)
        {
            return await _repositorioDeProduto.ObtePorId(id);
        }

        public async Task<ICollection<Produto>> ObterTodos()
        {
            return await _repositorioDeProduto.ObterProdutos();
        }
    }
}
