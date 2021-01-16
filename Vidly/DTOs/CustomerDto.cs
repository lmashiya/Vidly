using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.Validations;

namespace Vidly.DTOs
{
    public class CustomerDto
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
        ///      Gets or sets a <see cref="byte"/> representing membership id foreign key.
        /// </summary>
        public byte MembershipTypeId { get; set; }

        /// <summary>
        ///      Gets or sets a <see cref="DateTime"/> representing customer date of birth.
        /// </summary>
        //[Min18YearsIfMemberValidation]
        public DateTime? DateOfBirth { get; set; }
    }
}