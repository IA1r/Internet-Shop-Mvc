using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Layer.Dto
{

    /// <summary>
    /// User data transfer object
    /// </summary>
    public class UserDto
    {

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The user name.
        /// </value>
       public string Name { get; set; }

       /// <summary>
       /// Gets or sets the login.
       /// </summary>
       /// <value>
       /// The user login.
       /// </value>
       public string Login { get; set; }

       /// <summary>
       /// Gets or sets the role.
       /// </summary>
       /// <value>
       /// The user role.
       /// </value>
       public string Role { get; set; }

       /// <summary>
       /// Gets or sets the phone.
       /// </summary>
       /// <value>
       /// The user phone number.
       /// </value>
       public string Phone { get; set; }
    }
}