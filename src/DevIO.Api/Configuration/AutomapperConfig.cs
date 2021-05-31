using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Models;

namespace DevIO.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<CategoriaProdutoViewModel, CategoriaProduto>();
            CreateMap<EntradaSaidaProdutoViewModel, EntradaSaidaProduto>();

            CreateMap<EntradaSaidaProduto, EntradaSaidaProdutoViewModel>()
                .ForMember(dest => dest.NomeProduto, opt => opt.MapFrom(src => src.Produto.Nome));
        }
    }
}