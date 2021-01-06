using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {
        /// <summary>
        ///      Gets or sets a <see cref="byte"/> representing genre id.
        /// </summary>
        public byte Id { get; set; }

        /// <summary>
        ///      Gets or sets a <see cref="string"/> representing membership id.  
        /// </summary>
        public string Name { get; set; }
    }
}