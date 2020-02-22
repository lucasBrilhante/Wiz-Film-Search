using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wiz_Film_Search.Models;

namespace Wiz_Film_Search.Service
{
    public class MovieService : IMovieService
    {
        private string movieUrl;
        public MovieService(string url, string key)
        {
            movieUrl = url;
        }
        public List<Movie> GetMoviesAsync()
        {

            return null;
        }
    }
}
