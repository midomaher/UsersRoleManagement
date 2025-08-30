using AutoMapper;
using JwtRoleAuthentication.Application.DTOs;
using JwtRoleAuthentication.Application.Interfaces.Repositories;
using JwtRoleAuthentication.Application.Interfaces.Services;
using JwtRoleAuthentication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtRoleAuthentication.Application.Services
{
    public class PageService : IPageService
    {
        private readonly IPageRepository _repo; private readonly IMapper _mapper;
        public PageService(IPageRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<PageDto> CreateAsync(PageDto pageDto)
        {
            var page = _mapper.Map<Page>(pageDto);

            await _repo.AddAsync(page);

            return _mapper.Map<PageDto>(page);
        }

        public async Task<List<PageDto>> GetAllPagesAsync()
        {
            var pages = await _repo.GetAllAsync();
            return _mapper.Map<List<PageDto>>(pages);
        }

        public async Task<PageDto> GetByIdAsync(int id)
        {
            var page = await _repo.GetByIdAsync(id);
            return _mapper.Map<PageDto>(page);
        }
    }
}
