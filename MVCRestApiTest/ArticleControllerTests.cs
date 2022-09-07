using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MVCRestAPI.Controllers;
using MVCRestAPI.Data;
using MVCRestAPI.Models;
using MVCRestAPI.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
