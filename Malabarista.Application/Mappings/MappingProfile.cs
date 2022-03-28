using AutoMapper;
using Malabarista.Application.DTOs; //Acesso aos DTOs
using Malabarista.Domain.Entities; //Acesso aos dominios

namespace Malabarista.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Grain, GrainDTO>().ReverseMap();
            CreateMap<Taste, TasteDTO>().ReverseMap();

        }
    }
}
