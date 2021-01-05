﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        /// <summary>
        ///     Gets or sets a <see cref="byte"/> representing membership id.
        /// </summary>
        public byte Id { get; set; }

        /// <summary>
        ///      Gets or sets a <see cref="byte"/> representing duration of membership.
        /// </summary>
        public byte DurationInMonths { get; set; }

        /// <summary>
        ///      Gets or sets a <see cref="byte"/> representing discount rate for membership.
        /// </summary>
        public byte DiscountRate { get; set; }

        /// <summary>
        ///      Gets or sets a <see cref="short"/> representing sign up fee for membership.
        /// </summary>
        public short SignUpFee { get; set; }

    }
}