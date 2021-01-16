﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using AutoMapper;
using Vidly.App_Start;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.Single(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created( new Uri($"{Request.RequestUri}/{movieDto.Id}"), movieDto );
        }

        public IHttpActionResult Edit(MovieDto movieDto, int id)
        {
            var movieInDb = _context.Movies.Single(x => x.Id == id);

            if (!ModelState.IsValid) return BadRequest();
            if (movieInDb == null) return NotFound();

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }

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