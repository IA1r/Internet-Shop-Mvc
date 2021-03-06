//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel.Entity
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The Product class model in shoppingcart
    /// </summary>
    public partial class ProductCart
    {

        /// <summary>
        /// Gets or sets the product cart identifier.
        /// </summary>
        /// <value>
        /// The product cart identifier.
        /// </value>
        public int ProductCartID { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the shopping cart identifier.
        /// </summary>
        /// <value>
        /// The shopping cart identifier.
        /// </value>
        public string ShoppingCartID { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
