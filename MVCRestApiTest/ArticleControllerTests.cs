using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MVCRestAPI.Controllers;
using MVCRestAPI.Data;
using MVCRestAPI.DTOs;
using MVCRestAPI.Models;
using MVCRestAPI.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MVCRestApiTest
{
    public class ArticleControllerTests : IDisposable
    {
        Mock<IArticleAPIRepo> mockRepo;
        ArticleProfiles realProfile;
        MapperConfiguration config;
        IMapper mapper;

        public ArticleControllerTests()
        {
            mockRepo = new Mock<IArticleAPIRepo>();
            realProfile = new ArticleProfiles();
            config = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            mapper = new Mapper(config);
        }
        public void Dispose()
        {
            mockRepo = null;
            mapper = null;
            config = null;
            realProfile = null;
        }

        [Fact]
        public void GetarticleItems_ReturnZeroItems_WhenDbisEmpty()
        {
            //Arrange

            mockRepo.Setup(repo => repo.GetAllArticles()).Returns(GetArticles(0));

            var article = new ArticleController(mockRepo.Object, mapper);

            //Act
            var result = article.GetArticles();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetArticles_ReturnsItem_WhenDBHasONeItem()
        {
            //Arrange

            mockRepo.Setup(repo => repo.GetAllArticles()).Returns(GetArticles(1));

            var article = new ArticleController(mockRepo.Object, mapper);

            //Act
            var result = article.GetArticles();

            //Assert
            var okResult = result.Result as OkObjectResult;

            var articles = okResult.Value as List<ArticleReadDTO>;

            Assert.Single(articles);
        }

        [Fact]

        public void GetArticleById_Returns404NotFound_WhenNonExistentIdProvided()
        {
            //Arrange
            mockRepo.Setup(repo => repo.GetArticleById(0)).Returns(() => null);

            var controller = new ArticleController(mockRepo.Object, mapper);


            //Act
            var result = controller.GetArticleById(0);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetArticleByID_Returns200OK__WhenValidIDProvided()
        {
            //Arrange
            mockRepo.Setup(repo =>
            repo.GetArticleById(1)).Returns(new Article
            {
                Id = 1,
                Text = "mock",
                Title = "Mock",
                Type = "Mock"
            });
            var controller = new ArticleController(mockRepo.Object, mapper);
            //Act
            var result = controller.GetArticleById(1);
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        private List<Article> GetArticles(int num)
        {
            var articles = new List<Article>();

            if(num > 0)
            {
                articles.Add(new Article
                {
                    Id = 0,
                    Text = "Test",
                    Title = "Test Title",
                    Type = "Test Type"
                });
            }

            return articles;
        }
    }
}
