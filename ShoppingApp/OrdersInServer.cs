using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class OrdersInServer
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        public string UserName { get; set; }
        public OrdersInServer(string name, int quantity, string username)
        {
            ProductName = name;
            Quantity = quantity;
            UserName = username;

        }

    }
}
