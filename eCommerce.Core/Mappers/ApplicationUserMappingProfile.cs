using AutoMapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.DTO;

namespace eCommerce.Core.Mappers;

public class ApplicationUserMappingProfile : Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dest=>dest.UserId, opt=>opt.MapFrom(src=>src.UserId)) //Optional, only required when column name mismatch between src and dest 
            .ForMember(dest=>dest.Success, opt=>opt.Ignore())  
            .ForMember(dest=>dest.Token, opt=>opt.Ignore())  
            .ReverseMap();

        CreateMap<RegisterRequest, ApplicationUser>();
    }
}