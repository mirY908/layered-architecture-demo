using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int? MinProductSale { get; set; }

      public  double  SumPriceSale { get; set; }
        public bool IfEveryOne { get; set; }
        public DateTime StartSale { get; set; }
        public DateTime EndSale { get; set; }
        public Sale(int Id, int ProductId, int? MinProductSale, double SumPriceSale, bool IfEveryOne, DateTime StartSale, DateTime EndSale)
        {
            this.Id = Id;
            this.ProductId = ProductId;
            this.MinProductSale = MinProductSale;
            this.IfEveryOne = IfEveryOne;
            this.StartSale = StartSale;
            this.EndSale = EndSale;
        }
        public Sale()
        {
            
        }
        public override string ToString()
        {
            return $"Id: {Id}, ProductId: {ProductId}, MinProductSale: {MinProductSale}, IfEveryOne: {IfEveryOne}, StartSale: {StartSale}, EndSale: {EndSale}";
        }
    }
}
