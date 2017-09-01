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
    /// The copy POCO of Role class model
    /// </summary>
    public partial class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public int RoleID { get; set; }

        /// <summary>
        /// Gets or sets the role name for user.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    
        public virtual ICollection<User> Users { get; set; }
    }
}
