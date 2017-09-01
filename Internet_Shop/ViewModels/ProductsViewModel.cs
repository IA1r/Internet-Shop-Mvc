using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Layer.Dto;

namespace Internet_Shop.ViewModels
{

    /// <summary>
    /// ProductsViewModel class
    /// </summary>
    public class ProductsViewModel
    {

        /// <summary>
        /// Gets or sets the products data transfer object.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        public ProductsDto[] Products { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public ProductsDto Product { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the cart identifier.
        /// </summary>
        /// <value>
        /// The ShoppingCart identifier.
        /// </value>
        public string CartID { get; set; }
    }
}