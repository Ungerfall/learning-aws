using System;
using System.Collections.Generic;

namespace SimpleShoppingCart.Model
{
    public class ShoppingCart
    {
        public long ShoppingCartId { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}