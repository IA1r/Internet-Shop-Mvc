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
    /// The copy POCO of the model of Purchased product
    /// </summary>
    public partial class Purchased
    {

        /// <summary>
        /// Gets or sets the purchased identifier.
        /// </summary>
        /// <value>
        /// The purchased identifier.
        /// </value>
        public int PurchasedID { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the name of the buyer.
        /// </summary>
        /// <value>
        /// The name of the buyer.
        /// </value>
        public string BuyerName { get; set; }

        /// <summary>
        /// Gets or sets the date of purchase.
        /// </summary>
        /// <value>
        /// The date of purchase.
        /// </value>
        public System.DateTime DateOfPurchase { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The buyer phone number.
        /// </value>
        public string Phone { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
