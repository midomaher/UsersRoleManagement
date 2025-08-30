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
        private readonly IPageRepository _repo;
        public PageService(IPageRepository repo) {
            _repo = repo;
        }
        public async Task<PageDto> CreateAsync(PageDto pageDto)
        {
            var page = new Page
            {
                Id = pageDto.Id,
                Title = pageDto.Title,
                Author = pageDto.Author,
                Body = pageDto.Body,
            };
            await _repo.AddAsync(page);

            var pageDtoObj = new PageDto
            {
                Id = page.Id,
                Title = page.Title,
                Author = page.Author,
                Body = page.Body,
            };
            return pageDtoObj;
        }

        public async Task<List<PageDto>> GetAllPagesAsync()
        {
            var users = await _repo.GetAllAsync();
            return users.Select(page => new PageDto
            {
                Id = page.Id,
                Author = page.Author,
                Body = page.Body,
                Title = page.Title
            }).ToList();
        }

        public async Task<PageDto> GetByIdAsync(int id)
        {
            var page = await _repo.GetByIdAsync(id);

            var pageDtoObj = new PageDto
            {
                Id = page.Id,
                Title = page.Title,
                Author = page.Author,
                Body = page.Body,
            };
            return pageDtoObj;
        }
    }
}
