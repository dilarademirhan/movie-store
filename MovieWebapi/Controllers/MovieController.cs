using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using MovieWebapi.DBOperations;
using MovieWebapi.MovieOperations.GetMovies;

namespace MovieWebapi.AddControllers{
    [ApiController] // bu controller bir HTTP response dönecek 
    [Route("[controller]s")]
    public class MovieController : ControllerBase {

        private readonly MovieStoreDbContext _context;

        public MovieController(MovieStoreDbContext context){
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMoviesQuery query = new GetMoviesQuery(_context);
            var result = query.Handle();
            return Ok(result);
            // var movieList = _context.Movies.OrderBy(x => x.Id).ToList<Movie>();
            // return movieList;
        }

        [HttpGet("{id}")]
        public Movie GetById(int id)
        {
            var movie = _context.Movies.Where(movie => movie.Id == Convert.ToInt32(id)).SingleOrDefault();
            return movie;
        }
        
        
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie newMovie) //aslında postta bir şey dönülmez ama burada başarılı-başarısız
        //olma durumunu göstermek için IActionResult döndürüldü
        {
            var movie = _context.Movies.SingleOrDefault( x => x.Title == newMovie.Title);
            if(movie is not null) return BadRequest();
            _context.Movies.Add(newMovie); 
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie updatedMovie){
            var movie = _context.Movies.SingleOrDefault( x => x.Id == id);
            if (movie is null) return BadRequest();
            movie.Title = updatedMovie.Title != default ? updatedMovie.Title : movie.Title;
            movie.Year = updatedMovie.Year != default ? updatedMovie.Year : movie.Year;
            movie.GenreId = updatedMovie.GenreId != default ? updatedMovie.GenreId : movie.GenreId;
            movie.DirectorId = updatedMovie.DirectorId != default ? updatedMovie.DirectorId : movie.DirectorId;

            _context.SaveChanges(); 
            return Ok();
        }
        
        [HttpDelete]
        public IActionResult DeleteMovie(int id){
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if(movie is null) return BadRequest(); 
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            
            return Ok();
        }
    }
}