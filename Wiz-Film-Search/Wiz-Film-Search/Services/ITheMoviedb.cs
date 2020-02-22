using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wiz_Film_Search.Models;

namespace Wiz_Film_Search.Services
{
    public interface ITheMoviedb
    {
        [Get("/movie/upcoming?api_key={api_key}&page={page}")]
        Task<MovieList> GetLatestMovies([Query] int page, [Query] string api_key);
    }
}
