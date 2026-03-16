using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Sale
    {
        public int Id;
        public int ProductId;
        public int? MinProductSale;
        public Sale(int Id, int ProductId, int? MinProductSale)
        {
            this.Id = Id;
            this.ProductId = ProductId;
            this.MinProductSale = MinProductSale;
        }
    }
}
