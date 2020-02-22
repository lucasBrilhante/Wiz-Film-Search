using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wiz_Film_Search.Models;

namespace Wiz_Film_Search.Service
{
    public interface IMovieService
    {
        List<Movie> GetMoviesAsync();
    }
}
