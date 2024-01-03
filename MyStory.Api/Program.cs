using AutoMapper;
using MediumStory.Data.DataContext;
using MediumStory.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyStory.Api.Configurations;
using MyStory.Api.Configurations.Layers;
using MyStory.Data.Interfaces;
using MyStory.Data.Repositories;
using MyStory.DTOs;
using MyStory.Service.Interfaces;
using MyStory.Service.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// Data Configuration
builder.ConfigureDataAcces();

/// Service Configuration
builder.ConfigureService();

/// Cors configuration
builder.ConfigureCORSPolicy();


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MyMapper());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);



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
