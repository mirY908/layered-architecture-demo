using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do
{
      public record Product(int Id,string ProductName, Category Category,double Price,int? Amount)
      {
           public Product():this(123,"aaa", Category.Piza, 10.5,10) { }
      }    
}
