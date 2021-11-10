using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exp1
{
    public class Product
    {
        private int id;
        private string name;
        private decimal price;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}