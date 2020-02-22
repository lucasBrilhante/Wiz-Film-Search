using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wiz_Film_Search.Service;

namespace Wiz_Film_Search.Controllers
{
    [Route("/api/[controller]")]
    public class MovieController : Controller
    {
        IMovieService _movieService;
        
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int numberOfPages = 1)
        {
            try
            {
                var movies = await _movieService.GetMoviesAsync(numberOfPages);
                return Json(movies);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); // Log to a logging service
                return StatusCode(500);
            }
        }
    }
}