using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wiz_Film_Search.Models;
using Wiz_Film_Search.Services;

namespace Wiz_Film_Search.Service
{
    public class MovieService : IMovieService
    {
        private ITheMoviedb _movieRepo;
        private readonly string _movieKey;

        public MovieService(IConfiguration configuration, ITheMoviedb theMoviedb)
        {
            _movieRepo = theMoviedb;
            _movieKey = configuration["MoviesAPi:Key"];
        }

        public async Task<List<Movie>> GetMoviesAsync(int NumberOfPages)
        {
            bool nextPage = true;
            List<Movie> movies = new List<Movie>();
            int currentPage = 1;
            
            while (nextPage)
            {
                var pageMovies = await _movieRepo.GetLatestMovies(currentPage, _movieKey);

                movies.AddRange(pageMovies.Results);

                if (currentPage < NumberOfPages && currentPage < pageMovies.TotalPages)
                {
                    currentPage++;
                    continue;
                }
                else
                {
                    break;
                }

            }
            await OverrideGenres(movies);
            return movies;
        }

        private async Task OverrideGenres(List<Movie> movies)
        {
            var genresList = await _movieRepo.GetGenres(_movieKey);
            var genresDic = genresList.GetGenresDictionary();
            foreach (var movie in movies)
            {
                List<string> newGens = new List<string>();
                foreach (string gen in movie.GenreIds)
                {
                    newGens.Add(genresDic[gen]);
                }
                movie.GenreIds = newGens.ToArray();
            }
        }
    }
}
