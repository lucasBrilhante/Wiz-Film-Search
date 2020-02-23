using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wiz_Film_Search.Models;
using Wiz_Film_Search.Service;
using Wiz_Film_Search.Services;

namespace Wiz_Film_Search.Test.Services
{
    [TestClass]
    public class MovieServiceTest
    {
        private static int nonRepeatingNum = 0;
        [TestMethod]
        public async Task GetMoviesList_ExpectFullList()
        {
            //arrange
            Mock<ITheMoviedb> _mockRepo = new Mock<ITheMoviedb>();
            Mock<IConfiguration> _mockConfig = new Mock<IConfiguration>();

            _mockConfig.Setup(x => x["MoviesAPi:Key"]).Returns("thisisatestkey");
            _mockRepo.Setup(x => x.GetLatestMovies(1, It.IsAny<string>())).
                ReturnsAsync(GetMockMovieList(1));
            _mockRepo.Setup(x => x.GetLatestMovies(2, It.IsAny<string>())).
                ReturnsAsync(GetMockMovieList(1));
            _mockRepo.Setup(x => x.GetGenres(It.IsAny<string>())).
                ReturnsAsync(GetMockGenresList());

            //act
            MovieService service = new MovieService(_mockConfig.Object, _mockRepo.Object);
            var result = await service.GetMoviesAsync(2);
            //assert
            
            Assert.AreEqual(40, result.Count);
            Assert.AreEqual("Action", result[0].GenreIds[0]);
            _mockRepo.Verify(x=>x.GetLatestMovies(It.IsAny<int>(), "thisisatestkey"),Times.Exactly(2));

        }


        public MovieList GetMockMovieList(int i)
        {
            var list = new List<Movie>();

            string[] array = { "10", "20", "30", "40"};
            for (int j = 0; j < i * 20; j++)
            {
                list.Add(new Movie()
                {
                    Title ="Sonic the Hedgehog"+ nonRepeatingNum++,
                    ReleaseDate = "2020-02-12",
                    Overview = "Based on the global blockbuster videogame franchise from Sega",
                    GenreIds = array
                });
            }
            return new MovieList()
            {
                Page = 1,
                TotalPages = 10,
                TotalResults = 10000,
                Results = list
            };
        }
        public Genres GetMockGenresList()
        {
            var list = new List<Genre>();
            list.Add(new Genre()
            {
                Id = "10",
                Name = "Action"
            });
            list.Add(new Genre()
            {
                Id = "20",
                Name = "Adventure"
            });
            list.Add(new Genre()
            {
                Id = "30",
                Name = "Fantasy"
            });
            list.Add(new Genre()
            {
                Id = "40",
                Name = "Horror"
            });
            return new Genres()
            {
                GenresList = list
            };
        }
    }
}
