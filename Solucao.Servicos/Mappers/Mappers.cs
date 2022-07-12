using AutoMapper;
using Solucao.Domain.Entidades;
using Solucao.Servicos.Servicos_Dtos;

namespace Solucao.Servicos.Mappers
{
    public class Mappers : Profile
    {
       public Mappers()
        {
            CreateMap<Locacao, LocarDto>().ReverseMap();
            CreateMap<Locacao, DevolucaoDto>().ReverseMap();
            CreateMap<Locacao, LocacaoDto>().ReverseMap();
            CreateMap<Locador, LocadorDto>().ReverseMap();
            CreateMap<Locador, ClienteDto>().ReverseMap();
            CreateMap<Filme, FilmeDto>().ReverseMap();
            CreateMap<Filme, LocarFilmeDto>().ReverseMap();
        }
    }
}
