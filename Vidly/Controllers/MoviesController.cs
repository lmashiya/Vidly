using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    /// <summary>
    /// A controller for movies
    /// </summary>
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movie = new Movie(){Name = "Shrek",Id = 1};
            return View(movie);
        }
    }
}