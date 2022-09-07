using MVCRestAPI.Models;
using MVCRestAPI.Services;

namespace MVCRestAPI.Data
{
    public class SqlArticleAPIRepo : IArticleAPIRepo
    {
        private readonly ArticleDbContext _context;

        public SqlArticleAPIRepo(ArticleDbContext context)
        {
            _context = context;
        }

        public void CreateArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public void DeleteArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _context.Articles.ToList();
        }

        public Article GetArticleById(int id)
        {
            return _context.Articles.FirstOrDefault(a => a.Id == id);
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateArticle(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
