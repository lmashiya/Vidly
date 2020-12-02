using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    /// <summary>
    /// Represents a movie.
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Gets or sets a <see cref="string"/> representing the name of a movie.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets an <see cref="int"/> representing the id of a movie.
        /// </summary>
        public int Id { get; set; }
    }
}