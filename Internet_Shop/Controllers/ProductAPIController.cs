using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Layer.Dto;
using BusinessModel.Managers;

namespace Internet_Shop.Controllers
{
    public class ProductAPIController : ApiController
    {

        /// <summary>
        /// The product 
        /// </summary>
        private ProductManager productManager;
        public ProductAPIController()
        {
            productManager = new ProductManager();
        }

        /// <summary>
        /// Gets the product information.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ProductsDto GetProductInfo(int id)
        {
            return this.productManager.GetPurchasedProductInfo(id);
        }






    }
}
