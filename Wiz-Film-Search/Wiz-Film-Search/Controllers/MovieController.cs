using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wiz_Film_Search.Service;

namespace Wiz_Film_Search.Controllers
{
    public class MovieController : Controller
    {
        MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        } 
        public IActionResult Get()
        {
            var movies = _movieService.GetMoviesAsync();
            return Json(movies);
        }
    }
}