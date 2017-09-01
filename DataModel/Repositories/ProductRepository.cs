using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Layer.Model;
using Layer.Dto;
using Layer.Const;
using System.Web.Mvc;

namespace DataModel.Repositories
{
    public class ProductRepository
    {

        /// <summary>
        /// The ShopEntities context
        /// </summary>
        private ShopEntities1 context;

        /// <summary>
        /// The product data transfer object
        /// </summary>
        private ProductsDto product;

        /// <summary>
        /// The products data transfer object
        /// </summary>
        private ProductsDto[] products;
        public ProductRepository()
        {
            context = new ShopEntities1();
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <param name="productType">Type of the product.</param>
        /// <returns></returns>
        public ProductsDto[] GetProducts(string productType)
        {
            if (!context.Products.Any(p => p.ProductType == productType))
            {
                return null;
            }

            this.products = context.Products
                .Where(p => p.ProductType == productType)
                .Select(p => new
                {
                    product = new ProductsDto
                    {
                        Id = p.ProductID,
                        Name = p.Name,
                        ProductType = p.ProductType
                    },
                    characteristics = p.ProductCharacteristics
                    .Where(pc => pc.Characteristic.Name == CharacteristicConst.Image || pc.Characteristic.Name == CharacteristicConst.Price)
                        .Select(pc => new
                        {
                            Name = pc.Characteristic.Name,
                            Value = pc.CharacteristicValue
                        })
                })
                .AsEnumerable()
                .Select(x =>
                {
                    x.product.Characteristics = x.characteristics
                        .ToDictionary(c => c.Name, c => c.Value);

                    return x.product;

                }).ToArray();

            return this.products;
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns></returns>
        public ProductsDto GetProduct(int id)
        {
            if (!context.Products.Any(p => p.ProductID == id))
            {
                return null;
            }

            this.product = context.Products
               .Where(p => p.ProductID == id)
               .Select(p => new
               {
                   product = new ProductsDto
                   {
                       Id = p.ProductID,
                       Name = p.Name,
                       ProductType = p.ProductType
                   },
                   characteristics = p.ProductCharacteristics
                       .Select(pc => new
                       {
                           Name = pc.Characteristic.Name,
                           Value = pc.CharacteristicValue
                       })
               })
               .AsEnumerable()
               .Select(x =>
               {
                   x.product.Characteristics = x.characteristics
                       .ToDictionary(c => c.Name, c => c.Value);

                   return x.product;

               }).SingleOrDefault();

            return this.product;
        }

        /// <summary>
        /// Searches the products.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <returns></returns>
        public ProductsDto[] SearchProducts(string keyword)
        {
            this.products = context.Products
                .Where(product => product.Name.Contains(keyword))
                .Select(product => new ProductsDto
                {
                    Id = product.ProductID,

                    Name = product.Name,

                    ProductType = product.ProductType
                }).ToArray();

            return this.products;
        }

        /// <summary>
        /// Gets the purchased products.
        /// </summary>
        /// <param name="name">The buyer name.</param>
        /// <returns></returns>
        public PurchasedDto[] GetPurchasedProducts(string name)
        {
            if (!context.Purchaseds.Any(p => p.BuyerName == name))
            {
                return null;
            }

            PurchasedDto[] products = context.Purchaseds
                .Where(p => p.BuyerName == name)
                .Select(p => new PurchasedDto
                {
                    Id = p.PurchasedID,
                    ProductId = p.ProductID,
                    BuyerName = name,
                    Phone = p.Phone,
                    DateOfPurchase = p.DateOfPurchase
                })
                .ToArray();

            return products;
        }

        /// <summary>
        /// Gets the purchased product information.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns></returns>
        public ProductsDto GetPurchasedProductInfo(int id)
        {
            this.product = context.Purchaseds
                 .Where(p => p.ProductID == id)
                 .Select(p => new
                 {
                     product = new ProductsDto
                     {
                         Name = p.Product.Name,
                         ProductType = p.Product.ProductType
                     },
                     characteristics = p.Product.ProductCharacteristics
                     .Where(c => c.Characteristic.Name == CharacteristicConst.Image || c.Characteristic.Name == CharacteristicConst.Price || c.Characteristic.Name == CharacteristicConst.Description)
                         .Select(pc => new
                         {
                             Name = pc.Characteristic.Name,
                             Value = pc.CharacteristicValue
                         })
                 })
                 .AsEnumerable()
                 .Select(x =>
                 {
                     x.product.Characteristics = x.characteristics
                         .ToDictionary(c => c.Name, c => c.Value);

                     return x.product;

                 }).FirstOrDefault();

            return this.product;
        }


        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="image">The image.</param>
        public void AddProduct(ProductsDto product, HttpPostedFileBase image)
        {
            if (image != null)
            {
                string imageName = System.IO.Path.GetFileName(image.FileName);
                string imagePath = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Images"), imageName);
                image.SaveAs(imagePath);

                product.Characteristics.Add("1", "/Content/Images/" + imageName);
            }

            context.Products.Add(new Product
            {
                Name = product.Name,
                ProductType = product.ProductType
            });

            foreach (string key in product.Characteristics.Keys)
            {
                context.ProductCharacteristics.Add(new ProductCharacteristic
                {
                    CharacteristicID = Convert.ToInt32(key),
                    CharacteristicValue = product.Characteristics[key],
                    IsActive = true
                });
            };
            context.SaveChanges();
        }

        public List<SelectListItem> GetListTypes()
        {
            return context.Products
                .Select(p => new SelectListItem
                {
                    Text = p.ProductType,
                    Value = p.ProductType
                }).Distinct().ToList<SelectListItem>();
        }

    }
}