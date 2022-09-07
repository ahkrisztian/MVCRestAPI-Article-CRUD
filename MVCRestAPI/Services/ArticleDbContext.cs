using Microsoft.EntityFrameworkCore;
using MVCRestAPI.Models;
using System;
using System.Collections.Generic;

namespace MVCRestAPI.Services
{
    public class ArticleDbContext : DbContext
    {
        public ArticleDbContext(DbContextOptions<ArticleDbContext> opt) : base(opt)
        {

        }

        public DbSet<Article> Articles { get; set; }
    }
}
