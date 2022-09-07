using MVCRestAPI.Models;
using Xunit;

namespace MVCRestApiTest
{
    public class UnitTests : IDisposable
    {
        Article testArticle;

        public UnitTests()
        {
            testArticle = new Article()
            {
                Text = "Do somthing",
                Title = "Somthing",
                Type = "Smth"
            };
        }
        public void Dispose()
        {
            testArticle = null;
        }

        [Fact]
        public void ChangeText()
        {
            //Arrange


            //Act
            testArticle.Text = "Execute";

            //Assert
            Assert.Equal("Execute", testArticle.Text);
        }

        [Fact]
        public void ChangeTitle()
        {
            //Arrange


            //Act
            testArticle.Title = "Change Title";

            //Assert
            Assert.Equal("Change Title", testArticle.Title);
        }

        [Fact]
        public void ChangeType()
        {
            //Arrange


            //Act
            testArticle.Type = "Change Type";

            //Assert
            Assert.Equal("Change Type", testArticle.Type);
        }
    }
}