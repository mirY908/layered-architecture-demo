using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class SaleInProduct
    {
        public int id;
        public int amount;
        public int price;
        public bool ifEveryOne;

        public SaleInProduct() { }

        public SaleInProduct(int id, int amount, int price, bool ifEveryOne)
        {
            this.id = id;
            this.amount = amount;
            this.price = price;
            this.ifEveryOne = ifEveryOne;
        }
    }
}
