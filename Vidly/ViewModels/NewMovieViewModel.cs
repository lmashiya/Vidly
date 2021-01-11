using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.Validations;

namespace Vidly.ViewModels
{
    public class NewMovieViewModel
    {
        /// <summary>
        ///     Gets or sets a <see cref="IEnumerable{T}"/> representing a list of genres.
        /// </summary>
        public IEnumerable<Genre> Genres { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> representing the name of a movie.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets an <see cref="int"/> representing the id of a movie.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        ///  Gets or sets a <see cref="DateTime"/> representing release date of a movie.
        /// </summary>
        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        ///  Gets or sets a <see cref="byte"/> representing number of stock for a movie.
        /// </summary>
        [Display(Name = "Number of Stock")]
        [StockNumberValidation]
        [Required]
        public byte? NumberOfStock { get; set; }

        /// <summary>
        ///  Gets or sets a <see cref="byte"/> representing a foreign key of a genre.
        /// </summary>
        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        public NewMovieViewModel()
        {
            Id = 0;
        }

        public NewMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            NumberOfStock = movie.NumberOfStock;
        }

        /// <summary>
        ///     Gets or sets <see cref="string"/> representing the view title.
        /// </summary>
        public string Title => Id == 0 ? "New Movie" : "Edit Movie";
    }
}