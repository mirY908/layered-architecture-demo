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
        List<SaleInProduct> products;
        public double finalPrice;
    }
}
