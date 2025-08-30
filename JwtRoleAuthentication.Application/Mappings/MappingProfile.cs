using AutoMapper;
using JwtRoleAuthentication.Application.DTOs;
using JwtRoleAuthentication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtRoleAuthentication.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Example: Entity -> DTO
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Page, PageDto>();

            // Example: DTO -> Entity
            CreateMap<UserDto, ApplicationUser>();
            CreateMap<PageDto, Page>();

        }
    }
}
