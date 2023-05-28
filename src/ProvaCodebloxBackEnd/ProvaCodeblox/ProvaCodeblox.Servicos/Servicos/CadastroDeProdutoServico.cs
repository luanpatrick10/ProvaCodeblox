using ProvaCodeblox.Dominio.Entidades;
using ProvaCodeblox.Dominio.ObjetosDeDominio;
using ProvaCodeblox.Dominio.Repositoiros;
using ProvaCodeblox.Dominio.Servicos;
using ProvaCodeblox.Servicos.Excecoes;

namespace ProvaCodeblox.Servicos.Servicos
{
    public class CadastroDeProdutoServico : ServicosDeCRUD<Produto>, ICadastroDeProdutoServico
    {
        private IProdutoRepositorio _repositorioDeProduto;
        public CadastroDeProdutoServico(IProdutoRepositorio repositorioDeProduto) : base(repositorioDeProduto)
        {
            _repositorioDeProduto = repositorioDeProduto;
        }

        public async Task<Produto> ObterProdutoPorNome(string nome)
        {
            Produto produto = await _repositorioDeProduto.ObterProdutoPorNome(nome);
            ValidarSeConsultaNaoEstaNula(produto);
            return produto;
        }
        protected override async Task ValidarInclusao(Produto produto)
        {
            await ValidarSeEhProdutoNovo(produto);
            await ValidarSeEhNomeEhUnico(produto.Nome);
            base.ValidarInclusao(produto);
        }
        protected override async Task ValidaAlteracao(Produto produto)
        {
            await ValidarSeEhNomeEhUnico(produto.Nome);
            base.ValidaAlteracao(produto);
        }


        private async Task ValidarSeEhProdutoNovo(Produto produto)
        {
            try
            {
                await ObterPorId(produto.Id);
                throw new ValidacaoException(MensagensDeValidacoes.ObjetoJaCadastrado);
            }
            catch (NaoEncontradoException) { }
        }
        private async Task ValidarSeEhNomeEhUnico(string nomeDoProduto)
        {
            try
            {
                Produto produto = await ObterProdutoPorNome(nomeDoProduto);
                throw new ValidacaoException(MensagensDeValidacoes.ObjetoJaCadastradoComEsseNome(nameof(Produto)));
            }
            catch (NaoEncontradoException) { }
        }
    }
}
