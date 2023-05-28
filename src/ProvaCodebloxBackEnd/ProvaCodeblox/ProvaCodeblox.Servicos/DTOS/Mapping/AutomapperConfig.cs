using AutoMapper;
using ProvaCodeblox.Dominio.Entidades;

namespace ProvaCodeblox.Servicos.DTOS.Mapping
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<NovoProdutoDTO, Produto>();
            CreateMap<ProdutoDTO, Produto>();
        }
    }
}