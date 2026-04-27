using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ProductInOrder
    {
        public int id;
        public string name;
        public double minPrice;
        public int amount;
        //List<SaleInProduct> products;
        public List<SaleInProduct> products; 
        public double finalPrice;

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