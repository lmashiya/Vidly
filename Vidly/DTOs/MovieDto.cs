using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;
using Vidly.Validations;

namespace Vidly.App_Start
{
    public class MovieDto
    {
        /// <summary>
        /// Gets or sets a <see cref="string"/> representing the name of a movie.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets an <see cref="int"/> representing the id of a movie.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///  Gets or sets a <see cref="DateTime"/> representing release date of a movie.
        /// </summary>
        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        ///  Gets or sets a <see cref="DateTime"/> representing date movie was added.
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        ///  Gets or sets a <see cref="byte"/> representing number of stock for a movie.
        /// </summary>
        [Display(Name = "Number of Stock")]
        //[StockNumberValidation]
        [Required]
        public byte NumberOfStock { get; set; }

        /// <summary>
        ///  Gets or sets a <see cref="byte"/> representing a foreign key of a genre.
        /// </summary>
        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }
    }
}