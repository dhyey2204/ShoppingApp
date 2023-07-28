using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingClient
{
    public class OrdersFromServer
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        public string Username { get; set; }
        public OrdersFromServer(string name, int quantity, string username)
        {
            ProductName = name;
            Quantity = quantity;
            Username = username;

        }
    }
}
