using Microsoft.AspNetCore.Mvc;
using MVCRestAPI.Models;
using MVCRestAPI.Services;
using Microsoft.EntityFrameworkCore;
using MVCRestAPI.Data;
using AutoMapper;
using MVCRestAPI.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace MVCRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleAPIRepo _repo;
        private readonly IMapper _mapper;

        public ArticleController(IArticleAPIRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArticleReadDTO>> GetArticles()
        {
            var articles = _repo.GetAllArticles();

            return Ok(_mapper.Map<IEnumerable<ArticleReadDTO>>(articles));
        }

        [HttpGet("{id}", Name = "GetArticleById")]
        public ActionResult<ArticleReadDTO> GetArticleById(int id)
        {
            var commandItem = _repo.GetArticleById(id);

            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ArticleReadDTO>(commandItem));
        }

        [HttpPost]
        public ActionResult<ArticleReadDTO> CreateArticel (ArticleCreateDTO articleCreatDTO)
        {
            var article = _mapper.Map<Article>(articleCreatDTO);
            _repo.CreateArticle(article);

            var articleReadDto = _mapper.Map<ArticleReadDTO>(article);

            return CreatedAtRoute(nameof(GetArticleById),
                new { Id = articleReadDto.Id }, articleReadDto);

        }

        [HttpPut("{id}")]
        public ActionResult UpdateArticle(int id, ArticleUpdateDTO articleUpdateDTO)
        {
            var articleFromRepo = _repo.GetArticleById(id);

            if(articleFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(articleUpdateDTO, articleFromRepo);

            _repo.UpdateArticle(articleFromRepo);


            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialArticelUpdate(int id , JsonPatchDocument<ArticleUpdateDTO> patchDoc)
        {
            var articleFromRepo = _repo.GetArticleById(id);
            if (articleFromRepo == null)
            {
                return NotFound();
            }

            var articleToPatch = _mapper.Map<ArticleUpdateDTO>(articleFromRepo);

            patchDoc.ApplyTo(articleToPatch, ModelState);

            if (!TryValidateModel(articleToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(articleToPatch, articleFromRepo);

            _repo.UpdateArticle(articleFromRepo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteArticle(int id)
        {
            var articleFromRepo = _repo.GetArticleById(id);

            if (articleFromRepo == null)
            {
                return NotFound();
            }

            _repo.DeleteArticle(articleFromRepo);

            return NoContent();
        }
    }
}
