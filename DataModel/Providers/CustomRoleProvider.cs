using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Layer.Model;

namespace DataModel.Providers
{
    public class CustomRoleProvider: RoleProvider
    {

        /// <summary>
        /// The ShopEntities context
        /// </summary>
        private ShopEntities1 context;

        public CustomRoleProvider()
        {
            context = new ShopEntities1();
        }


        /// <summary>
        /// Gets the roles for user.
        /// </summary>
        /// <param name="userLogin">The user login.</param>
        /// <returns></returns>
        public override string[] GetRolesForUser(string userLogin)
        {
            string[] role = new string[] { };

            User user = context.Users.Where(u => u.Login == userLogin).SingleOrDefault();

            if (user != null)
            {
                Role userRole = context.Roles.Find(user.RoleID);

                if (userRole != null)
                {
                    role = new string[] { userRole.Name };
                }
            }

            return role; 
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}