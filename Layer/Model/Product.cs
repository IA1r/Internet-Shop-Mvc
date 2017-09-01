//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Layer.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The copy POCO of the product class model
    /// </summary>
    public partial class Product
    {
        public Product()
        {
            this.ProductCarts = new HashSet<ProductCart>();
            this.ProductCharacteristics = new HashSet<ProductCharacteristic>();
            this.Purchaseds = new HashSet<Purchased>();
        }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductID { get; set; }

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
    
        public virtual ICollection<ProductCart> ProductCarts { get; set; }
        public virtual ICollection<ProductCharacteristic> ProductCharacteristics { get; set; }
        public virtual ICollection<Purchased> Purchaseds { get; set; }
    }
}
