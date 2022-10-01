using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace MovieWebapi.DBOperations {
    public class DataGenerator 
    {
        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>())){
                if (context.Movies.Any())
                {
                    return;
                }

                context.Movies.AddRange(
                    new Movie {
                        Id =  1,
                        Title = "The Lobster",
                        Year = 2015,
                        GenreId = 1, //Drama
                        DirectorId = 1, //Yorgos Lanthimos
                    }
                );

                context.SaveChanges();
            }
        }
    }
}