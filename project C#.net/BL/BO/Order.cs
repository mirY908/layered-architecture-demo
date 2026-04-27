using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Order
    {
        public bool IsFavoriteCustomer;
        public List<ProductInOrder> ProductList { get; set; } = new List<ProductInOrder>();
        public double TotalPrice;
        public Order(bool IsFavoriteCustomer, double TotalPrice)
        {
            this.IsFavoriteCustomer = IsFavoriteCustomer;
            this.TotalPrice = TotalPrice;
        }
        public Order()
        {
            
        }
    }
}
