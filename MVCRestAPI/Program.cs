using Microsoft.EntityFrameworkCore;
using MVCRestAPI.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using MVCRestAPI.Data;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ArticleDbContext>(opt => opt.UseSqlServer("name=ConnectionStrings:Default"));


builder.Services.AddScoped<IArticleAPIRepo, SqlArticleAPIRepo>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
