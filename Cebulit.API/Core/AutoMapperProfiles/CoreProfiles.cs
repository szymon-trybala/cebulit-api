using AutoMapper;
using Cebulit.API.Core.Models;
using Cebulit.API.Dto.Core;
using Cebulit.API.Dto.Products.PcParts;
using Cebulit.API.Models.Auth;

namespace Cebulit.API.Core.AutoMapperProfiles
{
    public class CoreMaps : Profile
    {
        public CoreMaps()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductSet, ProductSetDto>();
            CreateMap<Tag, TagDto>();
            CreateMap<User.UserTagMatch, TagMatchDto>()
                .ForMember(x => x.Tag, m => m.MapFrom(y => y.Tag));
            CreateMap<User.UserBuildOrder, BuildOrderDto>()
                .ForMember(x => x.Build, m => m.MapFrom(y => y.Build))
                .ForPath(x => x.Build.IsGeneratedForUser, m => m.MapFrom(y => false));
            CreateMap<User.UserGeneratedBuildOrder, BuildOrderDto>()
                .ForMember(x => x.Build, m => m.MapFrom(y => y.UserGeneratedBuild))
                .ForPath(x => x.Build.IsGeneratedForUser, m => m.MapFrom(y => true));
            
        }
    }
}