using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Order
    {
        public bool favority;
        public List<ProductInOrder> orders;
        public double priceToPay;
        public Order(bool favority, double priceToPay)
        {
            this.favority = favority;
            this.priceToPay = priceToPay;
        }
    }
}
