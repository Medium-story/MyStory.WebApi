using AutoMapper;
using MyStory.DTOs;

namespace MyStory.Api.Configurations;

public static class MyMapperConfiguration
{
    public static void ConfigurationMapper(this WebApplicationBuilder builder)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MyMapper());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);
    }
}
