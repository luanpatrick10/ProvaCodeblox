using ProvaCodeblox.Dominio.Entidades;
using ProvaCodeblox.Dominio.ObjetoDeValor;
using ProvaCodeblox.Dominio.ObjetosDeDominio;

namespace ProvaCodeblox.Tests.Dominio
{
    public class ProdutoTest
    {
        [Test]
        public void TestaCriarProdutoComNomeNulo()
        {
            Assert.Throws<ExcecoesDeDominio>(() => new Produto(nome: "Maça", precoDeVenda: 10, descricao: "", quantidade: 10, tipo: ModoDeProducaoAgricula.Organico));
        }

        [Test]
        public void TestaCriarProdutoComPrecoDeVendaZerado()
        {
            Assert.Throws<ExcecoesDeDominio>(() => new Produto(nome: "Maça", precoDeVenda: -1, descricao: "", quantidade: 10, tipo: ModoDeProducaoAgricula.Organico));
        }

        [Test]
        public void TestaCriarProdutoComTipoNulo()
        {
            Assert.Throws<ExcecoesDeDominio>(() => new Produto(nome: "Maça", precoDeVenda: 10, descricao: "", quantidade: 10, null));
        }
    }
}