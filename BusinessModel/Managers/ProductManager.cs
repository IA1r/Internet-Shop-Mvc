using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Layer.Dto;
using DataModel.Repositories;
using System.Web;
using System.Web.Mvc;

namespace BusinessModel.Managers
{

    /// <summary>
    /// ProductManager class
    /// </summary>
    public class ProductManager
    {

        /// <summary>
        /// The product repository
        /// </summary>
        private ProductRepository repository;

        /// <summary>
        /// The products
        /// </summary>
        private ProductsDto[] products;

        /// <summary>
        /// The product
        /// </summary>
        private ProductsDto product;
        public ProductManager()
        {
            repository = new ProductRepository();
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <param name="productType">Type of the product.</param>
        public ProductsDto[] GetProducts(string productType)
        {
            this.products = repository.GetProducts(productType);
            if (products != null)
            {
                return this.products;
            }

            throw new ArgumentException("The product is not in storage");
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        public ProductsDto GetProduct(int id)
        {
            this.product = repository.GetProduct(id);
            if (product != null)
            {
                return this.product;
            }

            throw new ArgumentException("Product with this id does not exist");

        }

        /// <summary>
        /// Searches the products.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <returns></returns>
        public ProductsDto[] SearchProducts(string keyword)
        {
            this.products = repository.SearchProducts(keyword);

            return this.products;
        }

        /// <summary>
        /// Gets the purchased products.
        /// </summary>
        /// <param name="name">The buyer name.</param>
        public PurchasedDto[] GetPurchasedProducts(string name)
        {
            PurchasedDto[] products = repository.GetPurchasedProducts(name);

            if (products != null)
            {
                return products;
            }

            throw new ArgumentException("Product with this buyer does not exist");
        }

        /// <summary>
        /// Gets the purchased product information.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns></returns>
        public ProductsDto GetPurchasedProductInfo(int id)
        {
            return repository.GetPurchasedProductInfo(id);
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="image">The image.</param>
        public void AddProduct(ProductsDto product,HttpPostedFileBase image)
        {
            if (!product.Characteristics.Any(p => string.IsNullOrWhiteSpace(p.Value)) && (image != null))
            {
                repository.AddProduct(product, image);
            }
            else
            {
                throw new ArgumentException("Characteristics should not be empty");
            }
           
            
        }

        public List<SelectListItem> GetListTypes()
        {
            return repository.GetListTypes();
        }
    }
}
