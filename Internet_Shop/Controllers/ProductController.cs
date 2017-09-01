using Internet_Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Layer.Dto;
using BusinessModel.Managers;

namespace Internet_Shop.Controllers
{
    public class ProductController : Controller
    {

        /// <summary>
        /// The product view
        /// </summary>
        private ProductsViewModel productView;

        /// <summary>
        /// The product mamager
        /// </summary>
        private ProductManager productMamager;

        /// <summary>
        /// The purchased view
        /// </summary>
        private PurchasedViewModel purchasedView;

        /// <summary>
        /// The shopping cart manager
        /// </summary>
        private ShoppingCartManager shoppingCartManager;
        public ProductController()
        {
            productMamager = new ProductManager();
            shoppingCartManager = new ShoppingCartManager();
        }


        /// <summary>
        /// Products list page.
        /// </summary>
        /// <param name="productType">Type of the product.</param>
        [HttpGet]
        public ActionResult ProductsList(string productType)
        {
            try
            {
               this.productView = new ProductsViewModel
                {
                    Products = productMamager.GetProducts(productType)
                };
            }
            catch (ArgumentException ex)
            {
                return RedirectToAction("ErrorPage", "Product", new { error = ex.Message });
            }

            return View(this.productView);
        }

        /// <summary>
        /// Product page.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <param name="productType">Type of the product.</param>
        [HttpGet]
        public ActionResult Product(int id, string productType)
        {
            try
            {
                this.productView = new ProductsViewModel
                {
                    Product = productMamager.GetProduct(id),

                    CartID = shoppingCartManager.GetCartID(),
                    UserName = HttpContext.User.Identity.Name
                };
            }
            catch (ArgumentException ex)
            {
                return RedirectToAction("ErrorPage", "Product", new { error = ex.Message });
            }

            return View(this.productView);          
        }

        /// <summary>
        /// Searches the product.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <returns></returns>
        public PartialViewResult SearchProduct(string keyword)
        {
            ProductsDto[] products = productMamager.SearchProducts(keyword);

            return PartialView(products);
        }

        /// <summary>
        /// The info of purchased product.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult PurchasedProducts()
        {
           this.purchasedView = new PurchasedViewModel
            {
                Names = shoppingCartManager.GetBuyerNames()
            };
           return View(this.purchasedView);
        }

        /// <summary>
        /// The info of purchased product.
        /// </summary>
        /// <param name="name">The buyer name.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult PurchasedProducts(string name)
        {
            try
            {
               this.purchasedView = new PurchasedViewModel
                {
                    Products = productMamager.GetPurchasedProducts(name),

                    Names = shoppingCartManager.GetBuyerNames()
                };
            }
            catch (ArgumentException ex)
            {
                this.purchasedView = new PurchasedViewModel
                {
                    ErrorMessage = ex.Message
                };
            }

            return View(this.purchasedView);
            
        }

        /// <summary>
        /// Page to add some product.
        /// </summary>
        [HttpGet]
        [Authorize(Roles="Admin")]
        public ActionResult AddProduct()
        {
            return View(new AddProductViewModel
            {
                ListTypes = productMamager.GetListTypes()
            });
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="model">The model of product.</param>
        /// <param name="file">The image of product.</param>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddProduct(AddProductViewModel model, HttpPostedFileBase file)
        {
            if (model.ProductType != null)
            {
                model.ListTypes = productMamager.GetListTypes();
                return View(model);
            }
            try
            {
                productMamager.AddProduct(model.Product, file);
                return RedirectToAction("AddProduct", "Product");
            }
            catch (ArgumentException ex)
            {
                return RedirectToAction("ErrorPage", "Product", new { error = ex.Message });
            }
            
        }
        [HttpGet]
        [Authorize(Roles="Admin")]
        public ActionResult Options()
        {
            return View();
        }

        /// <summary>
        /// Error the page.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ErrorPage(string error)
        {
            return View("Error", null, error);
        }

        /// <summary>
        /// The home page.
        /// </summary>
        /// <returns></returns>
        public ActionResult HomePage()
        {
            return View();
        }

    }
}
