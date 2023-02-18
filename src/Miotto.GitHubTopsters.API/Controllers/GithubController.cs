using Microsoft.AspNetCore.Mvc;
using Miotto.GitHubTopsters.Service;
using Miotto.GitHubTopsters.Domain.Entities;
using Miotto.GitHubTopsters.Domain.Dtos;

namespace Miotto.GitHubTopsters.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GithubController : ControllerBase
    {
        private readonly IGithubService _service;

        public GithubController(IGithubService service)
        {
            _service = service;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List(int quantity, [FromHeader]List<string> languages)
        {
            var searchParams = new SearchGithubDto
            {
                Quantity = quantity,
                Languages = languages
            };

            var result = await _service.ListReposByLanguageAsync(searchParams);

            if (!result.Error)
                return Ok(result);

            return BadRequest(result);
        }
    }
}