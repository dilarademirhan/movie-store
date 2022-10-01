using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace MovieWebapi.AddControllers{
    [ApiController] // bu controller bir HTTP response dönecek 
    [Route("[controller]s")]
    public class MovieController : ControllerBase {
        private static List<Movie> MovieList = new List<Movie>(){
            
        };

        [HttpGet]
        public List<Movie> GetMovies()
        {
            var movieList = MovieList.OrderBy(x => x.Id).ToList<Movie>();
            return movieList;
        }

        [HttpGet("{id}")]
        public Movie GetById(int id)
        {
            var movie = MovieList.Where(movie => movie.Id == Convert.ToInt32(id)).SingleOrDefault();
            return movie;
        }
        
        
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie newMovie) //aslında postta bir şey dönülmez ama burada başarılı-başarısız
        //olma durumunu göstermek için IActionResult döndürüldü
        {
            var movie = MovieList.SingleOrDefault( x => x.Title == newMovie.Title);
            if(movie is not null) return BadRequest();
            MovieList.Add(newMovie); 
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie updatedMovie){
            var movie = MovieList.SingleOrDefault( x => x.Id == id);
            if (movie is null) return BadRequest();
            movie.Title = updatedMovie.Title != default ? updatedMovie.Title : movie.Title;
            movie.Year = updatedMovie.Year != default ? updatedMovie.Year : movie.Year;
            movie.GenreId = updatedMovie.GenreId != default ? updatedMovie.GenreId : movie.GenreId;
            movie.DirectorId = updatedMovie.DirectorId != default ? updatedMovie.DirectorId : movie.DirectorId;
            return Ok();
        }
        
        [HttpDelete]
        public IActionResult DeleteMovie(int id){
            var movie = MovieList.SingleOrDefault(x => x.Id == id);
            if(movie is null) return BadRequest(); 
            MovieList.Remove(movie);
            return Ok();
        }
    }
}