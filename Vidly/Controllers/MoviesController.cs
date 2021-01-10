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

        /// <summary>
        ///     Generates a form for new Movies.
        /// </summary>
        /// <returns>
        ///     A <see cref="ViewResult"/> representing the view for new movies and the viewmodel.
        /// </returns>
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new NewMovieViewModel()
            {
                Genres = genres
            };
            return View("MoviesForm",viewModel);
        }

        /// <summary>
        ///     Updates or adds a new movie to the database.
        /// </summary>
        /// <param name="movie">
        ///     A <see cref="Movie"/> representing a movie.
        /// </param>
        /// <returns>
        ///     A <see cref="RedirectResult"/> representing the view to be redirected to using then viewModel.    
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MoviesForm",viewModel);
            }
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

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null) return HttpNotFound();

            var viewModel = new NewMovieViewModel(movie)
            {
                Genres = _context.Genres.ToList(),
            };

            return View("MoviesForm",viewModel);
        }
    }
}