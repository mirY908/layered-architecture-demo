using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq; 

namespace Dal
{
    internal static class Config
    {
        private static string fileName = @"..\xml\data-config.xml";
        //private static string fileName = @"xml\dal-config.xml";
        public static int ProductNum
        {
            get
            {
                XElement root = XElement.Load(fileName);
                int id = int.Parse(root.Element("ProductNum").Value);

                root.Element("ProductNum").Value = (id + 1).ToString();
                root.Save(fileName);

                return id;
            }
        }

        public static int SaleNum
        {
            get
            {
                XElement root = XElement.Load(fileName);
                int id = int.Parse(root.Element("SaleNum").Value);

                root.Element("SaleNum").Value = (id + 1).ToString();
                root.Save(fileName);

                return id;
            }
        }
    }
}