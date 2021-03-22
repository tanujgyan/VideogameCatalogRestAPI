using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideogameCatalogRestAPI.Controllers;
using VideogameCatalogRestAPI.Entities;
using VideogameCatalogRestAPI.Services.Contracts;
using Xunit;

namespace VideoGameUnitTest
{
    public class VideoGameUnitTest
    {
        private VideogameController videogameController = null;
        private readonly int videogameId = 1;
        private readonly Mock<IVideogameService> videoGameStub = new Mock<IVideogameService>();
        Videogame sampleVideogame = new Videogame
        {
            VideogameId = 1,
            VideogameName = "Prince of Persia",
            Genere = "Action/Adventure",
            PublisherName = "Ubisoft",
            Platform = "PC"
        };
        Videogame toBePostedVideogame = new Videogame
        {
            VideogameName = "Prince of Persia",
            Genere = "Action/Adventure",
            PublisherName = "Ubisoft",
            Platform = "PC"
        };
        [Fact]
        public async Task GetVideoGame_BasedOnId_WithNotExistingVideogame_ReturnNotFound()
        {
            //Arrange
            //use the mock to set up the test. we are basically telling here that whatever int id we pass to this method 
            //it will always return null
            videogameController = new VideogameController(videoGameStub.Object);
            videoGameStub.Setup(service => service.GetVideogame(It.IsAny<int>())).ReturnsAsync((Videogame)null);
            //Act
            var actionResult = await videogameController.GetVideogame(1);
            //Assert
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }
        [Fact]
        public async Task GetVideoGame_BasedOnId_WithExistingVideogame_ReturnVideogame()
        {
            //Arrange
            //use the mock to set up the test. we are basically telling here that whatever int id we pass to this method 
            //it will always return a new Videogame object
            videoGameStub.Setup(service => service.GetVideogame(It.IsAny<int>())).ReturnsAsync(sampleVideogame);
            videogameController = new VideogameController(videoGameStub.Object);
            //Act
            var actionResult = await videogameController.GetVideogame(1);
            //Assert
            Assert.IsType<Videogame>(actionResult.Value);
            var result = actionResult.Value;
            sampleVideogame.Should().BeEquivalentTo(result,
                options => options.ComparingByMembers<Videogame>());
        }
        [Fact]
        public async Task PostVideoGame_WithNewVideogame_ReturnNewlyCreatedVideogame()
        {
            //Arrange
            videoGameStub.Setup(service => service.PostVideogame(It.IsAny<Videogame>())).ReturnsAsync(sampleVideogame);
            videogameController = new VideogameController(videoGameStub.Object);
            //Act
            var actionResult = await videogameController.PostVideogame(toBePostedVideogame);
            //Assert
            var postedVideogame = actionResult.Value;
            sampleVideogame.Should().BeEquivalentTo(postedVideogame,
                options => options.ComparingByMembers<Videogame>());
        }
        [Fact]
        public async Task PostVideoGame_WithException_ReturnsInternalServerError()
        {
            //Arrange
            videoGameStub.Setup(service => service.PostVideogame(It.IsAny<Videogame>())).Throws(new Exception());
            videogameController = new VideogameController(videoGameStub.Object);
            //Act
            var actionResult = await videogameController.PostVideogame(null);
            //Assert
            Assert.Equal("500",((StatusCodeResult)actionResult.Result).StatusCode.ToString());
        }
        [Fact]
        public async Task PutVideoGame_WithException_ReturnsConcurrencyExecption()
        {
            //Arrange
            videoGameStub.Setup(service => service.PutVideogame(It.IsAny<int>(),It.IsAny<Videogame>())).Throws(new DbUpdateConcurrencyException());
            videogameController = new VideogameController(videoGameStub.Object);
            //Act
            var actionResult = await videogameController.PutVideogame(videogameId, sampleVideogame);
            //Assert
            Assert.Equal("409", ((StatusCodeResult)actionResult).StatusCode.ToString());
            
        }
        [Fact]
        public async Task PutVideoGame_WithException_ReturnsExecption()
        {
            //Arrange
            videoGameStub.Setup(service => service.PutVideogame(It.IsAny<int>(), It.IsAny<Videogame>())).Throws(new Exception());
            videogameController = new VideogameController(videoGameStub.Object);
            //Act
            var actionResult = await videogameController.PutVideogame(videogameId, sampleVideogame);
            //Assert
            Assert.Equal("500", ((StatusCodeResult)actionResult).StatusCode.ToString());
        }
        [Fact]
        public async Task PutVideoGame_WithExistingVideogame_BasedOnId_ReturnUpdatedVideogame()
        {
            //Arrange
            videoGameStub.Setup(service => service.PutVideogame(It.IsAny<int>(), It.IsAny<Videogame>())).ReturnsAsync(new NoContentResult());
            videogameController = new VideogameController(videoGameStub.Object);
            //Act
            var actionResult = await videogameController.PutVideogame(videogameId,sampleVideogame);
            //Assert
            actionResult.Should().BeOfType<NoContentResult>();
        }
    }
}
