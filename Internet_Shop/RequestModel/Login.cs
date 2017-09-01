using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Internet_Shop.RequestModel
{

    /// <summary>
    /// The Login model
    /// </summary>
    public class Login
    {

        /// <summary>
        /// Gets or sets the user login.
        /// </summary>
        /// <value>
        /// The user login.
        /// </value>
        [Required(ErrorMessage = "Enter Login!", AllowEmptyStrings = false)]
        public string UserLogin { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The user password.
        /// </value>
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter password!", AllowEmptyStrings = false)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [remember me].
        /// </summary>
        /// <value>
        ///   <c>true</c> if selected; otherwise, <c>false</c>.
        /// </value>
        public bool RememberMe { get; set; }
    }
}