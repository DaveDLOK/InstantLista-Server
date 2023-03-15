using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InstantLista_ClassLibrary;
using InsantLista_Services.Interfaces;

namespace InstantLista_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly ILogger<NewsController> _logger;
    private readonly INewsService _newsService;

    public NewsController(ILogger<NewsController> logger, INewsService newsService)
    {
        _logger = logger;
        _newsService = newsService;
    }

    [HttpGet("get-news",Name = "GetNews")]
    public async Task<ActionResult<IEnumerable<NewsDto>>> GetNews()
    {
        var result = await _newsService.GetNews();

        return result != null ? result.ToList() : NotFound();
    }

    
}

