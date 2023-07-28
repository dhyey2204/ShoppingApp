using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingClient
{
    public class ProductsFromServer
    {
        public string ProductName { get; }
        public int Quantity { get; }

        public ProductsFromServer(string name, int quantity)
        {
            ProductName = name;
            Quantity = quantity;
        }
    }
}
