using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        /// <summary>
        ///  Gets or sets a <see cref="DateTime"/> representing release date of a movie.
        /// </summary>
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        ///  Gets or sets a <see cref="DateTime"/> representing date movie was added.
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        ///  Gets or sets a <see cref="byte"/> representing number of stock for a movie.
        /// </summary>
        [Display(Name = "Number of Stock")]
        public byte NumberOfStock { get; set; }

        /// <summary>
        ///  Gets or sets a <see cref="Genre"/> representing genre of a movie.
        /// </summary>
        [Display(Name = "Genre")]
        public Genre Genre { get; set; }

        /// <summary>
        ///  Gets or sets a <see cref="byte"/> representing a foreign key of a genre.
        /// </summary>
        public byte GenreId { get; set; }


    }
}