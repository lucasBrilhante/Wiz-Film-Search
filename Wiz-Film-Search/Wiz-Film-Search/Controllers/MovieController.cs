using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> Get()
        {
            var movies = await _movieService.GetMoviesAsync();
            return Json(movies.Results);
        }
    }
}