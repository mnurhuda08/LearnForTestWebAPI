using LearnForTestWebAPI.Models;

using Microsoft.AspNetCore.Mvc;

namespace LearnForTestWebAPI.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private static HttpClient _httpClient = new()
        {
            BaseAddress = new Uri( "https://jsonplaceholder.typicode.com/" )
        };
        [HttpGet]
        public async Task<ActionResult<List<Comment>>> Get( int? pageIndex )
        {
            var comments = await _httpClient.GetFromJsonAsync<List<Comment>>( $"comments" );

            var pageSize = 10;
            var paginatedList = await PaginatedList<Comment>.CreateAsync( comments , pageIndex ?? 1 , pageSize );
            return Ok( paginatedList );

        }
    }
}
