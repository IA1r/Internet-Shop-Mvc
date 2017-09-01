using Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessModel.Managers;
using Internet_Shop.RequestModel;

namespace Internet_Shop.Controllers
{
    public class AccountController : Controller
    {

        /// <summary>
        /// The provider
        /// </summary>
        private MemberManager provider;
        public AccountController()
        {

            provider = new MemberManager();
        }


        /// <summary>
        /// The Registers Page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        /// <summary>
        /// Registers the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                MembershipUser memberUser = provider.CreateUser(user);
            }
            catch (ArgumentException ex)
            {
                return RedirectToAction("ErrorPage", "Product", new { error = ex.Message });
            }

            FormsAuthentication.SetAuthCookie(user.Login, false);

            return RedirectToAction("HomePage", "Product");
        }


        /// <summary>
        /// The Login Page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Logins the specified user.
        /// </summary>
        /// <param name="login">The user login.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(Login login, string returnUrl = "")
        {
            bool isValidUser = provider.ValidateUser(login.UserLogin, login.Password);

            if (isValidUser)
            {
                FormsAuthentication.SetAuthCookie(login.UserLogin, login.RememberMe);
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("HomePage", "Product");
                }
            }

            return RedirectToAction("ErrorPage", "Product", new { error = "Wrong login or password. Be careful, this site supports validation case." });
        }

        /// <summary>
        /// Log out.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("HomePage", "Product");
        }
    }
}
