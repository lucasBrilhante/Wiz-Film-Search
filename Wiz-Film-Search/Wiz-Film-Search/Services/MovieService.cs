using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Wiz_Film_Search.Models;

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

        public async Task<MovieList> GetMoviesAsync()
        {
            string query = "&page=1";
            var request = new HttpRequestMessage(HttpMethod.Get, _movieUrl + "top_rated" + "?api_key=" + _movieKey + query);
            //request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();

                MovieList movies= JsonConvert.DeserializeObject
                    <MovieList>(responseStream);
                return movies;
            }
            else
            {
                return null;
            }
        }
    }
}
