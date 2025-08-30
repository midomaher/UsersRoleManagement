using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using JwtRoleAuthentication.Application.DTOs;
using JwtRoleAuthentication.Application.Interfaces.Services;

namespace JwtRoleAuthentication.Controllers;

[ApiVersion(1.0)]
[ApiController]
[Route("api/[controller]")]
public class PagesController : ControllerBase
{
    private readonly IPageService _pageService;

    public PagesController(ILogger<PagesController> logger, IPageService pageService)
    {
        _pageService = pageService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("new")]
    public async Task<ActionResult<PageDto>> CreatePage(PageDto pageDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var page = await _pageService.CreateAsync(pageDto);

        return CreatedAtAction(nameof(GetPage), new { id = page.Id }, page);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<PageDto>> GetPage(int id)
    {
        var pageDto = await _pageService.GetByIdAsync(id);

        return pageDto;
    }


    [HttpGet]
    public async Task<List<PageDto>> ListPages()
    {
        var pageList = await _pageService.GetAllPagesAsync();

        return pageList;
    }
}