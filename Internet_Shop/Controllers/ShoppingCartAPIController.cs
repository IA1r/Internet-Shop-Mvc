using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Layer.Model;
using BusinessModel.Managers;

namespace Internet_Shop.Controllers
{
    public class ShoppingCartAPIController : ApiController
    {

        /// <summary>
        /// The shopping cart manager
        /// </summary>
        private ShoppingCartManager shoppingCartManager;

        /// <summary>
        /// The member provider
        /// </summary>
        private MemberManager memberProvider;
        public ShoppingCartAPIController()
        {
            shoppingCartManager = new ShoppingCartManager();
            memberProvider = new MemberManager();
        }


        /// <summary>
        /// Adds the product for unknown user.
        /// </summary>
        /// <param name="id">The user(guest) identifier.</param>
        /// <param name="shoppingCart">The shopping cart.</param>
        [HttpPut]
        public void AddProductAnonym(int id, [FromBody]ShoppingCart shoppingCart)
        {
            this.shoppingCartManager.AddProductAnonym(id, shoppingCart);
        }


        /// <summary>
        /// Adds the product for identified user.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <param name="userLogin">The user login.</param>
        [HttpPut]
        public void AddProductUser(int id,[FromBody]string userLogin)
        {
            this.shoppingCartManager.AddProductUser(id, userLogin);
        }

        /// <summary>
        /// Purchases the products.
        /// </summary>
        [HttpPut]
        public void PurchaseProducts()
        {
            this.shoppingCartManager.PurchaseProducts();
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        [HttpDelete]
        public void DeleteProduct(int id)
        {
            this.shoppingCartManager.DeleteProduct(id);
        }

        /// <summary>
        /// Gets the user role.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetUserRole()
        {
           return memberProvider.GetUserRole();
        }
    }
}
