using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProvaCodeblox.Dominio.Entidades;
using ProvaCodeblox.Dominio.Servicos;
using ProvaCodeblox.Servicos.DTOS;

namespace ProvaCodeblox.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private ICadastroDeProdutoServico _cadastroDeProduto;
        private IMapper _mapper;
        public ProdutoController(ICadastroDeProdutoServico cadastroDeProduto, IMapper mapper)
        {
            _cadastroDeProduto = cadastroDeProduto;
            _mapper = mapper;
        }

        [HttpPost("cadastrar-produto")]
        public async Task<IActionResult> CadastrarProduto(NovoProdutoDTO novoProdutoDTO)
        {
            try
            {
                await _cadastroDeProduto.Criar(_mapper.Map<Produto>(novoProdutoDTO));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("obter-todos-produtos")]
        public async Task<ActionResult<IEnumerable<Produto>>> ObterProdutos()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<Produto>>(await _cadastroDeProduto.ObterTodos()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("obter-produto/{id}")]
        public async Task<ActionResult<Produto>> ObterProduto(int id)
        {
            try
            {
                return Ok(_mapper.Map<Produto>(await _cadastroDeProduto.ObterPorId(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("deletar-produto")]
        public async Task<ActionResult> DeletarProduto(int id)
        {
            try
            {
                await _cadastroDeProduto.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("atualizar-produto")]
        public async Task<ActionResult> AtualizarProduto(ProdutoDTO produtoDTO)
        {
            try
            {
                await _cadastroDeProduto.Atualizar(_mapper.Map<Produto>(produtoDTO));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
