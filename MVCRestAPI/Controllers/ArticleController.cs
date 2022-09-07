using Microsoft.AspNetCore.Mvc;
using MVCRestAPI.Models;
using MVCRestAPI.Services;
using Microsoft.EntityFrameworkCore;
using MVCRestAPI.Data;
using AutoMapper;
using MVCRestAPI.DTOs;

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

        [HttpGet("{id}")]
        public ActionResult<ArticleReadDTO> GetCommand(int id)
        {
            var commandItem = _repo.GetArticleById(id);

            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ArticleReadDTO>(commandItem));
        }
       
    }
}
