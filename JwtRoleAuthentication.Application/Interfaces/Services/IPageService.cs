using JwtRoleAuthentication.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtRoleAuthentication.Application.Interfaces.Services
{
    public interface IPageService
    {
        Task<PageDto> CreateAsync(PageDto pageDto);
        Task<List<PageDto>> GetAllPagesAsync();
        Task<PageDto> GetByIdAsync(int id);

    }
}
