using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Layer.Dto;
using Layer.Const;
using Layer.Model;


namespace DataModel.Repositories
{

    public class CartRepository
    {

        /// <summary>
        /// The ShopEntities context
        /// </summary>
        private ShopEntities1 context;

        /// <summary>
        /// The user identifier
        /// </summary>
        private string userID;

        public CartRepository()
        {
            context = new ShopEntities1();

            int currentUserId = context.Users
                .Where(u => u.Login == HttpContext.Current.User.Identity.Name)
                .Select(u => u.UserID)
                .SingleOrDefault();

            userID = currentUserId == 0
                ? "guest_" + HttpContext.Current.Request.AnonymousID
                : "user_" + currentUserId;
        }


        /// <summary>
        /// Gets the shopping cart identifier.
        /// </summary>
        public string GetCartID()
        {
            string cartID = null;

            if (context.ShoppingCarts.Any(c => c.ShoppingCartID == this.userID))
            {
                cartID = this.userID;
            }

            return cartID;
        }


        /// <summary>
        /// Adds the product for unknown user.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <param name="cart">The cart.</param>
        public void AddProductAnonym(int id, ShoppingCart cart)
        {
             
            if (!context.ShoppingCarts.Any(sc => sc.ShoppingCartID == this.userID))
            {
                cart.ShoppingCartID = this.userID; 
                cart.ProductCarts.Add(new ProductCart
                {
                    ProductID = id
                });
                context.ShoppingCarts.Add(cart);
            }
            else
            {
                context.ProductCarts.Add(new ProductCart
                {
                    ProductID = id,
                    ShoppingCartID = this.userID
                });
            }

            context.SaveChanges();
        }

        /// <summary>
        /// Adds the product for identified user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="userLogin">The user login.</param>
        public void AddProductUser(int id, string userLogin)
        {
            UserDto user = context.Users
                .Where(u => u.Login == userLogin)
                .Select(u => new UserDto
                {
                    Name = u.Name,
                    Phone = u.Phone
                })
                .Single();

            ShoppingCart cart = context.ShoppingCarts
                .Where(c => c.ShoppingCartID == this.userID)
                .SingleOrDefault();

            if (cart == null)
            {
                cart = new ShoppingCart();
                cart.Owner = user.Name;
                cart.Phone = user.Phone;
                cart.ShoppingCartID = this.userID;

                context.ShoppingCarts.Add(cart);
            }

            ProductCart product = new ProductCart
            {
                ProductID = id,
                ShoppingCartID = cart.ShoppingCartID
            };

            context.ProductCarts.Add(product);
            context.SaveChanges();
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        public ProductsDto[] GetProducts()
        {
            if (!context.ProductCarts.Any(p => p.ShoppingCartID == this.userID))
            {
                return null;
            }

            return context.ProductCarts
                .Where(sc => sc.ShoppingCartID == this.userID)
                .Select(p => new
                {
                    product = new ProductsDto
                    {
                        Id = p.ProductID,
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

                }).ToArray();
        }


        /// <summary>
        /// Gets owner name of shopping cart.
        /// </summary>
        public string GetOwnerName()
        {
            return context.ProductCarts
                .Where(p => p.ShoppingCartID == this.userID)
                .Select(name => name.ShoppingCart.Owner)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the total price in shopping cart.
        /// </summary>
        public string GetTotalPrice()
        {
            string totalPrice = "";
            int value = 0;
            string[] prices = context.ProductCarts
                .Where(product => product.ShoppingCartID == this.userID)
                .Select(product => product.Product.ProductCharacteristics
                    .Where(c => c.Characteristic.Name == CharacteristicConst.Price)
                    .Select(p => p.CharacteristicValue)
                    .FirstOrDefault()).ToArray();


            for (int i = 0; i < prices.Length; i++)
            {
                value += Convert.ToInt32(prices[i].Remove(prices[i].IndexOf(" ")));
            }

            totalPrice = value.ToString() + " $";
            return totalPrice;
        }

        /// <summary>
        /// Gets the buyer names.
        /// </summary>
        public string[] GetBuyerNames()
        {
            string[] names = context.Purchaseds
                .Where(product => product.DateOfPurchase == DateTime.Today)
                .Select(product => product.BuyerName).Distinct()
                .ToArray();

            return names;
        }

        /// <summary>
        /// Purchases the products.
        /// </summary>
        public void PurchaseProducts()
        {
            Purchased[] purchased = context.ProductCarts
                .Where(product => product.ShoppingCartID == this.userID)
                .ToArray()
               .Select(product => new Purchased
               {
                   ProductID = product.ProductID,
                   BuyerName = product.ShoppingCart.Owner,
                   DateOfPurchase = DateTime.Today,
                   Product = product.Product,
                   Phone = product.ShoppingCart.Phone
               }).ToArray();

            foreach (Purchased pur in purchased)
            {
                context.Purchaseds.Add(pur);
            }

            ProductCart[] products = context.ProductCarts
                .Where(prod => prod.ShoppingCartID == this.userID)
                .ToArray();

            foreach (ProductCart product in products)
            {
                context.ProductCarts.Remove(product);
            }

            ShoppingCart shoppingCart = context.ShoppingCarts
                .Where(cart => cart.ShoppingCartID == this.userID)
                .SingleOrDefault();

            context.ShoppingCarts.Remove(shoppingCart);


            context.SaveChanges();
        }

        /// <summary>
        /// Deletes the product from shopping cart.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteProduct(int id)
        {
            ProductCart product = context.ProductCarts
                .Where(prod => prod.ProductID == id)
                .FirstOrDefault();


            context.ProductCarts.Remove(product);

            context.SaveChanges();
        }

    }
}