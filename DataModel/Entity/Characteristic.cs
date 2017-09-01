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
    /// The Characteristic class model
    /// </summary>
    public partial class Characteristic
    {
        public Characteristic()
        {
            this.ProductCharacteristics = new HashSet<ProductCharacteristic>();
        }

        /// <summary>
        /// Gets or sets the characteristic identifier.
        /// </summary>
        /// <value>
        /// The characteristic identifier.
        /// </value>
        public int CharacteristicID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The characteristic name.
        /// </value>
        public string Name { get; set; }
    
        public virtual ICollection<ProductCharacteristic> ProductCharacteristics { get; set; }
    }
}
