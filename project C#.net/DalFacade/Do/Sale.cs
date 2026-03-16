using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do
{
    public record Sale(int Id,int ProductId, int? MinProductSale,
        double? SumPriceSale,bool IfEveryOne,DateTime StartSale,DateTime? EndSale)
    {
        public Sale(int V) : this(10,5, 123, 20.5, true, DateTime.Now, DateTime.Now) 
        {
           
        }

        //public static implicit operator Sale(Product v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
