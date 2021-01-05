using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        /// <summary>
        ///     Gets or sets an <see cref="int"/> representing the id for a customer.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        ///     Gets or sets a<see cref="string"/> representing the customer name.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        ///     Gets or sets a <see cref="bool"/> representing is customer subscribed to news letter.
        /// </summary>
        public bool IsSubscribedToNewsletter { get; set; }
    }
}