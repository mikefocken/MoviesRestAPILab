using Microsoft.AspNetCore.Mvc;
using MoviesWebAPi.Data;
using MoviesWebAPi.Models;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesWebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/Movies
        [HttpGet]
        public IActionResult Get()
        {
            var movies = _context.Movies.ToList();

            
            return Ok(movies);

        }   

        // GET api/Movies
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _context.Movies.Find(id);
            return Ok (movie);
        }

        // POST api/Movies
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Ok (movie);
        }

        // PUT api/Movies
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {
            var movieFromDb = _context.Movies.Find(id);

            if (movieFromDb != null)
            {
                NotFound();
            }
            movieFromDb.Title = movie.Title;
            movieFromDb.RunningTime = movie.RunningTime;
            movieFromDb.Genre = movie.Genre;

            _context.Movies.Update(movieFromDb);
            _context.SaveChanges();


            return Ok(movieFromDb);
        }

        // DELETE api/Movies
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movieFromDb = _context.Movies.Find(id);
           
            if (movieFromDb != null) 
            {
                _context.Movies.Remove(movieFromDb);
                _context.SaveChanges();
            }

            return NoContent();

        }
    }
}
