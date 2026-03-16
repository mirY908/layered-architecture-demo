using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal sealed class DalList : IDal
    {
        private static readonly DalList instance=new DalList();
        public static DalList Instance { get { return instance; } }

        public ISale Sale => new SaleImplementation(); 
        public IProduct Product => new ProductImplementation(); 
        public ICustomer Custemer => new CustemerImplementation();

        private DalList() { }

       

    }
}