using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewCustomerViewModel
    {
        /// <summary>
        ///      Gets or sets a <see cref="Customer"/> representing a customer.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        ///      Gets or sets an <see cref="IEnumerable{T}"/> representing the membership types..
        /// </summary>
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}