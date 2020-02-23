﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Wiz_Film_Search.Models;

namespace Wiz_Film_Search.Service
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMoviesAsync(int numberOfPages);
    }
}
