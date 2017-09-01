using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Layer.Dto;

namespace Internet_Shop.ViewModels
{

    /// <summary>
    /// ShoppingCartViewModel class
    /// </summary>
    public class ShoppingCartViewModel
    {

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products in shoppingCart.
        /// </value>
        public ProductsDto[] Products { get; set; }

        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        /// <value>
        /// The total price.
        /// </value>
        public string TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner of shoppingcart.
        /// </value>
        public string Owner { get; set; }
    }
}