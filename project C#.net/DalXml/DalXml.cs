using DalApi;
using Dal;
using System;

namespace DalXml
{

    internal sealed class DalXml : IDal
    {
        private static readonly DalXml instance = new DalXml();

        public static DalXml Instance { get { return instance; } }

        public ISale Sale { get; } = new SaleImplementation();
        public IProduct Product { get; } = new ProductImplementation();
        public ICustomer Custemer { get; } = new CustemerImplementation();

        private DalXml() { }
    }
}