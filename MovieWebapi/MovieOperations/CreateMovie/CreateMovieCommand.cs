using MovieWebapi.DBOperations;
using MovieWebapi.Common;
using System;
using System.Collections.Generic;

namespace MovieWebapi.MovieOperations.GetMovies
{
    public class CreateMovieCommand {

        public CreateMovieModel Model { get; set; }
        private readonly MovieStoreDbContext _dbContext;
        public CreateMovieCommand(MovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(){

        }
    }

    public class CreateMovieModel
    {
        public string Title { get; set; }    

        public int Year { get; set; } 
        public string Genre { get; set; }
        
        public string Director { get; set; }

        public int Price { get; set; }

    }
}