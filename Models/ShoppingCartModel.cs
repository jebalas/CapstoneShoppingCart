using System;
using System.Collections.Generic;

namespace CapstoneWk4ShoppingList.Models
{
    public class ShoppingCartModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public List<Products> ShoppingList { get; set; } = new List<Products>();
    }
}
