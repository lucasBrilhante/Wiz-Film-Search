using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wiz_Film_Search.Models
{
    public class Genres
    {
        [JsonProperty("genres")]
        public List <Genre> GenresList { get; set; }

        public Dictionary<string,string> GetGenresDictionary()
        {
            Dictionary<string, string> genresDic = new Dictionary<string, string>();

            foreach(Genre gen in GenresList)
            {
                genresDic.Add(gen.Id, gen.Name);
            }

            return genresDic;
        }
    }

    public class Genre
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
