using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Layer.Dto
{

    /// <summary>
    /// Purchased product data transfer object
    /// </summary>
    public class PurchasedDto
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The Purchased identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductId { get; set; }

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
        public DateTime DateOfPurchase { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The buyer phone nuber.
        /// </value>
        public string Phone { get; set; }
    }
}