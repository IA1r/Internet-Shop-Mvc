using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using Layer.Dto;
using Layer.Model;

namespace DataModel.Providers
{
    public class CustomMembershipProvider : MembershipProvider
    {

        /// <summary>
        /// The ShopEntities context
        /// </summary>
         private ShopEntities1 context;

         public CustomMembershipProvider()
        {
            context = new ShopEntities1();
        }


         /// <summary>
         /// Creates the user.
         /// </summary>
         /// <param name="user">The user.</param>
         public MembershipUser CreateUser(User user)
         {
             MembershipUser membershipUser = GetUser(user.Login, user.Email);

             if (membershipUser == null)
             {
                 user.RoleID = context.Roles.Where(r => r.Name == "User").FirstOrDefault().RoleID;

                 context.Users.Add(user);
                 context.SaveChanges();

                 membershipUser = GetUser(user.Login, user.Email);
                 return membershipUser;
             }
             else
             {
                 throw new ArgumentException("The user is already registered");
             }
         }

         /// <summary>
         /// Gets the user.
         /// </summary>
         /// <param name="userLogin">The user login.</param>
         /// <param name="email">The user email.</param>
         public MembershipUser GetUser(string userLogin, string email)
         {
             var user = context.Users.SingleOrDefault(u => u.Login == userLogin || u.Email == email);

             if (user != null)
             {
                 MembershipUser memberUser = new MembershipUser("CustomMembershipProvider", user.Login, null, null, null, null,
                         false, false, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
                 return memberUser;
             }
             else
             {
                 return null;
             }
         }

         /// <summary>
         /// Validates the user.
         /// </summary>
         /// <param name="userlogin">The userlogin.</param>
         /// <param name="password">The user password.</param>
         public override bool ValidateUser(string userlogin, string password)
         {
             var user = context.Users.SingleOrDefault(u => u.Login == userlogin && u.Password == password);

             if (user == null)
             {
                 return false;
             }
             return true;
         }

         /// <summary>
         /// Gets the user role.
         /// </summary>
         public string GetUserRole()
         {
             string userRole = context.Users
                 .Where(u => u.Login == HttpContext.Current.User.Identity.Name)
                 .Select(u => u.Role.Name).SingleOrDefault();
                 
            return userRole;
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

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

       
    }
}