using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Wiz_Film_Search.Models;
using Wiz_Film_Search.Util;

namespace Wiz_Film_Search.Service
{
    public class MovieService : IMovieService
    {
        private readonly string _movieUrl;
        private readonly string _movieKey;
        private IHttpClientFactory _clientFactory;
        public MovieService(IConfiguration configuration, IHttpClientFactory clientFactory)
        {  
            _movieUrl = configuration["MoviesAPi:Url"];
            _movieKey = configuration["MoviesAPi:Key"];
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync(int NumberOfPages)
        {
            bool nextPage = true;
            List<Movie> movies = new List<Movie>();
            string query = "&page=";
            int currentPage = 1;

            while (nextPage)
            {
                
                var request = new HttpRequestMessage(HttpMethod.Get, _movieUrl + "?api_key=" + _movieKey + query + currentPage);
                //request.Headers.Add("Accept", "application/json");

                var client = _clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStringAsync();

                    MovieList pageMovies = JsonConvert.DeserializeObject
                        <MovieList>(responseStream);
                    movies.AddRange(pageMovies.Results);
                    
                    if(currentPage <= NumberOfPages && currentPage < pageMovies.TotalPages)
                    {
                        currentPage++;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    throw new HttpRequestException();
                }
            }
            return movies;
        }
    }
}
