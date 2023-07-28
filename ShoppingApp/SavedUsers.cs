using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class SavedUsers
    {
        public string UserName { get; set; }
        public int Accno { get; set; }

        public SavedUsers(string name, int number)
        {
            UserName = name;
            Accno = number;
        }
    }
}
