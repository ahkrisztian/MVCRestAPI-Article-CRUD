using MVCRestAPI.Models;

namespace MVCRestAPI.Data
{
    public interface IArticleAPIRepo
    {
        IEnumerable<Article> GetAllArticles();
        Article GetArticleById(int id);
        void CreateArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(Article article);
    }
}
