using AutoMapper;
using MyStory.Api.Configurations;
using MyStory.Api.Configurations.Layers;
using MyStory.DTOs;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

/// Jwt configuration
builder.ConfigureJwtAuth();

/// Swagger Authorization Configuration
builder.ConfigureSwaggerAuth();

/// Data Configuration
builder.ConfigureDataAcces();

/// Service Configuration
builder.ConfigureService();

/// Cors configuration
builder.ConfigureCORSPolicy();

/// Mapper configuration
builder.ConfigurationMapper();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

/// Role Configuration
app.SeedRolesToDatabase();

app.Run();
