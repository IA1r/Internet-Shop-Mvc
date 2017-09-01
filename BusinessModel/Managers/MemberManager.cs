using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Providers;
using System.Web.Security;
using Layer.Model;

namespace BusinessModel.Managers
{

    /// <summary>
    /// MemberManager class
    /// </summary>
    public class MemberManager
    {

        /// <summary>
        /// The provider
        /// </summary>
        private CustomMembershipProvider provider;
        public MemberManager()
        {
            provider = new CustomMembershipProvider();
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public MembershipUser CreateUser(User user)
        {
            return provider.CreateUser(user);
        }

        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="userlogin">The userlogin.</param>
        /// <param name="password">The user password.</param>
        /// <returns></returns>
        public bool ValidateUser(string userlogin, string password)
        {
            return provider.ValidateUser(userlogin, password);
        }

        /// <summary>
        /// Gets the user role.
        /// </summary>
        /// <returns></returns>
        public string GetUserRole()
        {
            return provider.GetUserRole();
        }
    }
}
