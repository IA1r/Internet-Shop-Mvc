using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessModel.Managers;
using Internet_Shop.ViewModels;



namespace Internet_Shop.Controllers
{
    public class ShoppingCartController : Controller
    {

        /// <summary>
        /// The shopping cart manager
        /// </summary>
        private ShoppingCartManager shoppingCartManager;

        /// <summary>
        /// The shoppingcart
        /// </summary>
        private ShoppingCartViewModel shoppingcart;
        public ShoppingCartController()
        {
            shoppingCartManager = new ShoppingCartManager();
            shoppingcart = new ShoppingCartViewModel();
        }

        /// <summary>
        /// Shows the shopping cart.
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowCart()
        {
            this.shoppingcart.Products = shoppingCartManager.GetProducts();
            this.shoppingcart.TotalPrice = shoppingCartManager.GetTotalPrice();

            if (HttpContext.User.Identity.Name != "")
            {
                this.shoppingcart.Owner = HttpContext.User.Identity.Name;             
            }
            else
            {
                this.shoppingcart.Owner = shoppingCartManager.GetOwnerName();              
            }

            return View(this.shoppingcart);
        }

    }
}
