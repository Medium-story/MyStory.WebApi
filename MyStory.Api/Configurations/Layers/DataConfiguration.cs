using MediumStory.Data.DataContext;
using MediumStory.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyStory.Data.Interfaces;
using MyStory.Data.Repositories;

namespace MyStory.Api.Configurations.Layers;

public static class DataConfiguration
{
    public static void ConfigureDataAcces(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options => 
                         options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
        builder.Services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<AppDbContext>()
               .AddDefaultTokenProviders();

        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}
