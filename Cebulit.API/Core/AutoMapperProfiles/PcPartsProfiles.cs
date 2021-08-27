using AutoMapper;
using Cebulit.API.Dto.Products.PcParts;
using Cebulit.API.Models.Products.PcParts;

namespace Cebulit.API.Core.AutoMapperProfiles
{
    public class PcPartsProfiles : Profile
    {
        public PcPartsProfiles()
        {
            CreateMap<Case, CaseDto>();
            CreateMap<GraphicsCard, GraphicsCardDto>();
            CreateMap<Memory, MemoryDto>();
            CreateMap<Motherboard, MotherboardDto>();
            CreateMap<PowerSupply, PowerSupplyDto>();
            CreateMap<Processor, ProcessorDto>();
            CreateMap<Storage, StorageDto>();
            CreateMap<Build, BuildDto>()
                .ForMember(x => x.IsGeneratedForUser, m => m.MapFrom(y => false));
            CreateMap<UserBuild, BuildDto>()
                .ForMember(x => x.IsGeneratedForUser, m => m.MapFrom(y => true));
        }
    }
}