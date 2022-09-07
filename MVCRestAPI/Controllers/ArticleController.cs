using Microsoft.AspNetCore.Mvc;
using MVCRestAPI.Models;
using MVCRestAPI.Services;
using Microsoft.EntityFrameworkCore;
using MVCRestAPI.Data;

namespace MVCRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleAPIRepo _repo;

        public ArticleController(IArticleAPIRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Article>> GetArticles()
        {
            var articles = _repo.GetAllArticles();

            return Ok(articles);
        }

        [HttpGet("{id}")]
        public ActionResult<Article> GetCommand(int id)
        {
            var commandItem = _repo.GetArticleById(id);

            if (commandItem == null)
            {
                return NotFound();
            }

            return commandItem;
        }
       
    }
}
