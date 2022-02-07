using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("Seeding data");

                context.Platforms.AddRange(
                    new Platform(){Name = "Name1", Publisher = "Anna", Cost = "Free"},
                    new Platform(){Name = "Name2", Publisher = "Anna2", Cost = "Free"},
                    new Platform(){Name = "Name3", Publisher = "Anna3", Cost = "Free"}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("we don't have data");
            }
        }
    }
}