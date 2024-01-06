using AutoMapper;
using MyStory.Api.Configurations;
using MyStory.Api.Configurations.Layers;
using MyStory.DTOs;

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

#region Add Mapper configuration
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MyMapper());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
