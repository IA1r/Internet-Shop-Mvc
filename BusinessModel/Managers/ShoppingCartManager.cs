using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Layer.Dto;
using DataModel.Repositories;
using Layer.Model;
using BusinessModel.Managers;

namespace BusinessModel.Managers
{
    public class ShoppingCartManager
    {

        /// <summary>
        /// The shopping cart repository
        /// </summary>
        private CartRepository repository;

        /// <summary>
        /// The provider
        /// </summary>
        private MemberManager provider;
        public ShoppingCartManager()
        {
            repository = new CartRepository();
            provider = new MemberManager();
        }

        /// <summary>
        /// Gets the shopping cart identifier.
        /// </summary>
        /// <returns></returns>
        public string GetCartID()
        {
            return repository.GetCartID();
        }

        /// <summary>
        /// Gets the buyer names.
        /// </summary>
        /// <returns></returns>
        public string[] GetBuyerNames()
        {
            return repository.GetBuyerNames();
        }

        /// <summary>
        /// Gets the products in shopping cart.
        /// </summary>
        /// <returns></returns>
        public ProductsDto[] GetProducts()
        {
            return repository.GetProducts();
        }

        /// <summary>
        /// Gets the total price in shopping cart.
        /// </summary>
        /// <returns></returns>
        public string GetTotalPrice()
        {
            return repository.GetTotalPrice();
        }

        /// <summary>
        /// Gets owner name of shopping cart.
        /// </summary>
        /// <returns></returns>
        public string GetOwnerName()
        {
            return repository.GetOwnerName();
        }

        /// <summary>
        /// Adds the product for unknown user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="shoppingCart">The shopping cart.</param>
        public void AddProductAnonym(int id, ShoppingCart shoppingCart)
        {
            repository.AddProductAnonym(id, shoppingCart);
        }

        /// <summary>
        /// Adds the product for identified user.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <param name="userLogin">The user login.</param>
        public void AddProductUser(int id, string userLogin)
        {
            repository.AddProductUser(id, userLogin);
        }

        /// <summary>
        /// Purchases the products.
        /// </summary>
        public void PurchaseProducts()
        {
            repository.PurchaseProducts();
        }

        /// <summary>
        /// Deletes the product from shopping cart.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteProduct(int id)
        {
            repository.DeleteProduct(id);
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
