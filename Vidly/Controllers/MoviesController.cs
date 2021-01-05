using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    /// <summary>
    ///     The controller for movies.
    /// </summary>
    public class MoviesController : Controller
    {
        public ActionResult Index()
        {
            var movies = GetMovies();

            var viewModel = new RandomMovieViewModel()
            {
                Movies = movies
            };

            return View(viewModel);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie(){Name = "Shrek"},
                new Movie(){Name = "John Wick"},
                new Movie(){Name = "Mary Poppins"}
            };
        }
    }
}