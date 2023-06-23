using Nowadays.Api.DataAccess;
using Nowadays.Api.DataAccess.Repositories.CompanyRepositories;
using Nowadays.Api.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MediatR;
using Nowadays.Api.Common.Mappings.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NowadaysDbContext>(options => 
options.UseNpgsql(builder.Configuration.GetConnectionString("NowaDaysDb")));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
 builder.Services.AddDependencyResolver();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
