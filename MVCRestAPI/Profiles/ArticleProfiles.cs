using AutoMapper;
using MVCRestAPI.DTOs;
using MVCRestAPI.Models;

namespace MVCRestAPI.Profiles

{
    public class ArticleProfiles : Profile
    {
        public ArticleProfiles()
        {
            CreateMap<Article, ArticleReadDTO>();
            CreateMap<ArticleCreateDTO, Article>();
            CreateMap<ArticleUpdateDTO, Article>();
            CreateMap<Article, ArticleUpdateDTO>();
        }
    }
}
