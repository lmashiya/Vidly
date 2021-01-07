using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    /// <summary>
    ///     The controller for movies.
    /// </summary>
    public class MoviesController : Controller
    {
        /// <summary>
        ///     A <see cref="DbContext"/> representing the applications database context.
        /// </summary>
        private ApplicationDbContext _context;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MoviesController"/> class.
        /// </summary>
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        /// <inheritdoc cref="Dispose"/>
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        /// <summary>
        ///     Gets a list of movies.
        /// </summary>
        /// <returns>
        ///     A <see cref="ViewResult"/> with the list of movies.
        /// </returns>
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            if (!movies.Any()) return HttpNotFound();

            return View(movies);
        }

        /// <summary>
        ///     Gets a movie using the movie id.
        /// </summary>
        /// <param name="id">
        ///     An <see cref="int"/> representing a movie id.
        /// </param>
        /// <returns>
        ///     A <see cref="ViewResult"/> with a movie.
        /// </returns>
        public ActionResult Details(int? id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(x => x.Id == id);

            if (movie == null) return HttpNotFound();

            return View(movie);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new NewMovieViewModel()
            {
                Genres = genres
            };
            return View("MoviesForm",viewModel);
        }

        public ActionResult Save(Movie movie)
        {
            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(x => x.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberOfStock = movie.NumberOfStock;
            }
            _context.SaveChanges();

            return Content("Hello World");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null) return HttpNotFound();

            var viewModel = new NewMovieViewModel()
            {
                Genres = _context.Genres.ToList(),
                Movie = movie

            };

            return View("MoviesForm",viewModel);
        }
    }
}