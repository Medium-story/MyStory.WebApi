using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Net.Http.Headers;

namespace MyStory.Api.Configurations;

public static class CorsPolicyConfiguration
{
    public static void ConfigureCORSPolicy(this WebApplicationBuilder builder)
    {
        const string CORS_POLICY = "AllowAll";
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: CORS_POLICY,
                                     builder =>
                                     {
                                         builder.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader();
                                     });
        });
    }
}