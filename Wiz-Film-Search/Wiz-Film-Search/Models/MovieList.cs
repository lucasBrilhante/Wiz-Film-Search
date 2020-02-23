using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wiz_Film_Search.Models
{
    public class MovieList
    {
        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("total_results")]
        public long TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("results")]
        public List<Movie> Results { get; set; }
    }
}
