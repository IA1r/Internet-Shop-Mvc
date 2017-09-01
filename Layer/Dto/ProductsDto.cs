using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Layer.Dto
{

    /// <summary>
    /// Product data transfer object
    /// </summary>
    public class ProductsDto
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The product name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the product.
        /// </summary>
        /// <value>
        /// The type of the product.
        /// </value>
        public string ProductType { get; set; }

        public Dictionary<string, string> Characteristics { get; set; }


    }
}