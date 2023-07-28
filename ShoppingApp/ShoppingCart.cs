using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class ShoppingCart
    {     //m_locks to locks
        private static readonly object locks = new object();
        public List<ProductsInServer> Products { get; set; }
        public List<SavedUsers> Users { get; set; }
        Random random = new Random();
        public string UserName { get; set; }
        public string ProductName { get; set; }

        public int Accno { get; set; } = 0;

        private string orderstatus { get; set; }

        List<OrdersInServer> orders = new List<OrdersInServer>();


        public ShoppingCart()
        {
            
            Products = new List<ProductsInServer>();
            Users = new List<SavedUsers>();
            getitems();
            lock (locks) 
            {
                Accno++;
            }
            
           
            

        }
        public void getitems()
        {
            
            //Users = users;
            Products.Add(new ProductsInServer("Fruits", random.Next(1, 3)));
            Products.Add(new ProductsInServer("Eggs", random.Next(1, 3)));
            Products.Add(new ProductsInServer("Cereals", random.Next(1, 3)));
            Products.Add(new ProductsInServer("Snacks", random.Next(1, 3)));
            Products.Add(new ProductsInServer("chocolates", random.Next(1, 3)));
            Products.Add(new ProductsInServer("krackers", random.Next(1, 3)));
            Products.Add(new ProductsInServer("Tissues", random.Next(1, 3)));
            //adding user
            Users.Add(new SavedUsers("Dhyey", 1111));
            Users.Add(new SavedUsers("Sita", 2222));
            Users.Add(new SavedUsers("Vaishnav", 3333));


        }

        public List<ProductsInServer> GetProducts()
        {
            return Products;

        }
        public (bool, string) checkuser(int accno)
        {
            //(List<ProductsInServer> product, List<SavedUsers> sav) = getitems();
            var user = (from p in Users where p.Accno == accno select p.UserName).FirstOrDefault();
            if (string.IsNullOrEmpty(user))
            {
                return (false, "");

            }
            return (true, user);

        }
        public List<OrdersInServer> GetOrders()
        {

            //string status = 
            if (UserName != null && ProductName != null && orderstatus != "NOT_AVAILABLE" && orderstatus != "NOT_VALID")
            {
                orders.Add(new OrdersInServer(ProductName, 1, UserName));
                ProductName = null;
                return orders;

            }
            else if(orderstatus == "NOT_AVAILABLE" && orderstatus == "NOT_VALID")
            {
                return null;
            }            
            return orders;
           

        }
        public string purchase(string productname)
        {
            bool checkproduct = false;

            checkproduct = (from name in Products where name.ProductName == ProductName select true).FirstOrDefault();
            if (checkproduct)
            {
                var quantity = (from name in Products where name.ProductName == ProductName select name.Quantity).FirstOrDefault();
                var qua = Products.FirstOrDefault(c => c.ProductName == ProductName);
                if (quantity != 0)
                {

                    quantity--;
                    qua.Quantity = quantity;
                    orderstatus = "DONE";
                    return "DONE";

                }
                else
                {
                    orderstatus = "NOT_AVAILABLE";
                    return "NOT_AVAILABLE";

                }

            }
            else 
            {
                orderstatus = "NOT_VALID";
                return "NOT_VALID";

            }
            



        }
    }
            

}
 
