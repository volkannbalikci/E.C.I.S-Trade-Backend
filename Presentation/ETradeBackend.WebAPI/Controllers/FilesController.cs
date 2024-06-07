using ETradeBackend.WebAPI.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeBackend.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilesController : CustomControllerBase
{
    readonly IConfiguration _configuration;

    public FilesController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("[action]")]
    public IActionResult GetBaseStorageUrl()
    {
        return Ok(new
        {
            Url = _configuration["BaseStorageUrl"]
        });
    }
}
