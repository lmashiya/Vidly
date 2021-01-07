using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewMovieViewModel
    {
        /// <summary>
        ///     Gets or sets a <see cref="Movie"/> representing a movie.
        /// </summary>
        public Movie Movie { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="IEnumerable{T}"/> representing a list of genres.
        /// </summary>
        public IEnumerable<Genre> Genres { get; set; }
    }
}