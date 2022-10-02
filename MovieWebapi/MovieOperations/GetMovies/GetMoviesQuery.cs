using Microsoft.EntityFrameworkCore;
using MovieWebapi.DBOperations;
using System.Collections.Generic;
using System.Linq;
using MovieWebapi.Common;

namespace MovieWebapi.MovieOperations.GetMovies 
{
    public class GetMoviesQuery 
    {
        private readonly MovieStoreDbContext _dbContext;
        public GetMoviesQuery(MovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<MoviesViewModel> Handle(){
            var movieList = _dbContext.Movies.OrderBy(x => x.Id).ToList<Movie>();
            List<MoviesViewModel> vm = new List<MoviesViewModel>();
            foreach(var movie in movieList){
                vm.Add(new MoviesViewModel(){
                    Title = movie.Title,
                    Genre = ((GenreEnum) movie.GenreId).ToString(),
                    Year = movie.Year,
                    Director = ((DirectorEnum) movie.DirectorId).ToString()
                });
            }
            return vm;
        }
    }

    public class MoviesViewModel
    {
        public string Title { get; set; }    

        public int Year { get; set; } 
        public string Genre { get; set; }
        
        public string Director { get; set; }

        public int Price { get; set; }


    }
}