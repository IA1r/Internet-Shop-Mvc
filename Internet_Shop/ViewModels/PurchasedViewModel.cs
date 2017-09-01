using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Layer.Dto;

namespace Internet_Shop.ViewModels
{

    /// <summary>
    /// PurchasedViewModel class
    /// </summary>
    public class PurchasedViewModel
    {

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The Purchased products.
        /// </value>
        public PurchasedDto[] Products { get; set; }

        /// <summary>
        /// Gets or sets the names.
        /// </summary>
        /// <value>
        /// The buyer names.
        /// </value>
        public string[] Names { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }
    }
}