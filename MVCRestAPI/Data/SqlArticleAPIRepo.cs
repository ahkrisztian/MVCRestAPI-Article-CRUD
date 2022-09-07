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
            if(article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

        public void DeleteArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentException(nameof(article));
            }

            _context.Articles.Remove(article);
            _context.SaveChanges();
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _context.Articles.ToList();
        }

        public Article GetArticleById(int id)
        {
            return _context.Articles.FirstOrDefault(a => a.Id == id);
        }


        public void UpdateArticle(Article article)
        {
            _context.SaveChanges();
        }
    }
}
