using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using AutoMapper;
using Vidly.App_Start;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();
        //}

        public IHttpActionResult GetMovies()
        {
            var movieDtoList = _context.Movies.Include(x => x.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDtoList);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.Single(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            var m = Mapper.Map<Movie, MovieDto>(movie);
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            movieDto.DateAdded = DateTime.Now;
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created( new Uri($"{Request.RequestUri}/{movieDto.Id}"), movieDto );
        }
        //Put api/Movies/1
        [HttpPut]
        public IHttpActionResult Edit(MovieDto movieDto, int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (!ModelState.IsValid) return BadRequest();
            if (movieInDb == null) return NotFound();

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok(movieDto);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault();

            if (movieInDb == null) return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}