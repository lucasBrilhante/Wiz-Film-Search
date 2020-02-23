using Refit;
using System.Threading.Tasks;
using Wiz_Film_Search.Models;

namespace Wiz_Film_Search.Services
{
    public interface ITheMoviedb
    {
        [Get("/movie/upcoming?api_key={api_key}&page={page}")]
        Task<MovieList> GetLatestMovies([Query] int page, [Query] string api_key);

        [Get("/genre/movie/list?api_key={api_key}")]
        Task<Genres> GetGenres([Query] string api_key);
    }
}
