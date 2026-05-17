using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ProductInOrder
    {
        public int id { get; set; }
        public string name { get; set; }
        public double minPrice { get; set; }
        public int amount { get; set; }
        //List<SaleInProduct> products;
        public List<SaleInProduct> products { get; set; }
        public double finalPrice { get; set; }

        public ProductInOrder()
        {
           
        }

       
        public ProductInOrder(int id, double price, int amount)
        {
            this.id = id;
            this.minPrice = price;
            this.amount = amount;
            this.products = new List<SaleInProduct>();
        }
    }
}