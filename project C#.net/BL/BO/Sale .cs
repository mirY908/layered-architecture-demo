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

      public  double  SumPriceSale { get; set; }
        public bool IfEveryOne { get; set; }
        public DateTime StartrSale;
        public DateTime EndSale;
        public Sale(int Id, int ProductId, int? MinProductSale, double SumPriceSale, bool IfEveryOne, DateTime StartrSale, DateTime EndSale)
        {
            this.Id = Id;
            this.ProductId = ProductId;
            this.MinProductSale = MinProductSale;
            this.IfEveryOne = IfEveryOne;
            this.StartrSale = StartrSale;
            this.EndSale = EndSale;
        }
        public Sale()
        {
            
        }
    }
}
