using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        /// <summary>
        ///     Gets or sets a <see cref="bool"/> representing is customer subscribed to news letter.
        /// </summary>
        public bool IsSubscribedToNewsletter { get; set; }

        /// <summary>
        ///      Gets or sets a <see cref=" MembershipType"/> representing membership type for customer.
        /// </summary>
        public MembershipType MembershipType { get; set; }

        /// <summary>
        ///      Gets or sets a <see cref="byte"/> representing membership id foreign key.
        /// </summary>
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        /// <summary>
        ///      Gets or sets a <see cref="DateTime"/> representing customer date of birth.
        /// </summary>
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }
    }
}