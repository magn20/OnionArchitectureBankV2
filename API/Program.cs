using Application.DTOs;
using AutoMapper;
using Domain;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

var mapper = new MapperConfiguration(config =>
    config.CreateMap<PostPersonDTO, Person>()).CreateMapper();
        // person => postpersondto
builder.Services.AddDbContext<RepositoryDbContext>(options => options.UseSqlite(
    "Data source=db.db"
));

builder.Services.AddSingleton(mapper);

Application.DependencyResolver
    .DependencyResolverService
    .RegisterApplicationLayer(builder.Services);

Infrastructure.DependencyResolver.DependencyResolverService.RegisterInfrastructure(builder.Services);


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