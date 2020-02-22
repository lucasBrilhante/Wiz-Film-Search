using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wiz_Film_Search.Controllers;
using Wiz_Film_Search.Models;
using Wiz_Film_Search.Service;

namespace Wiz_Film_Search.Test.Controllers
{
    [TestClass]
    public class MovieControllerTest
    {
        [TestMethod]
        public async Task GetMovies_ExpectOk()
        {
            //Setup
            Mock<IMovieService> mockRepo = new Mock<IMovieService>();
            mockRepo.Setup(x => x.GetMoviesAsync(3)).ReturnsAsync(GetMockMovies(3));
            MovieController controller = new MovieController(mockRepo.Object);
            
            //Execute
            var result = await controller.Get(3) as JsonResult;
            
            //Assert
            mockRepo.Verify(x => x.GetMoviesAsync(3), Times.Once);
            Assert.IsTrue(((List<Movie>)result.Value).Count == 60);
        }

        //test exceptions and other stuff

        public List<Movie> GetMockMovies(int i)
        {
            var list = new List<Movie>();
            long[] array = { 10, 20, 30, 40 };
            for (int j = 0; j < i*20; j++)
            {
                list.Add(new Movie()
                {
                    Title = "Sonic the Hedgehog",
                    ReleaseDate = "2020-02-12",
                    Overview = "Based on the global blockbuster videogame franchise from Sega",
                    GenreIds = array
                });
            }
            return list;
        }
    }
}
