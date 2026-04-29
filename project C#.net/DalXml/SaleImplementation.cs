//using DalApi;
//using Do;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Xml.Linq;

//namespace Dal
//{
//    internal class SaleImplementation : ISale
//    {
//        //string path = @"..xml\sales.xml";
//        //string path = @"xml\sales.xml";
//        //string path = @"xml\sales.xml";

//        string path = @"..\xml\sales.xml";


//        public int Create(Sale item)
//        {
//            XElement SaleRoot = XElement.Load(path);
//            int id = Config.SaleNum; 

//            XElement s = new XElement("Sale",
//                         new XElement("Id", id), 
//                         new XElement("ProductId", item.ProductId), 
//                         new XElement("MinProductSale", item.MinProductSale),
//                         new XElement("SumPriceSale", item.SumPriceSale),
//                         new XElement("IfEveryOne", item.IfEveryOne),
//                         new XElement("StartSale", item.StartSale), 
//                         new XElement("EndSale", item.EndSale));

//            SaleRoot.Add(s);
//            SaleRoot.Save(path);
//            return id;
//        }

//        public Sale? Read(int id)
//        {
//            XElement root = XElement.Load(path);
//            XElement? s = root.Elements("Sale").FirstOrDefault(x => (int?)x.Element("Id") == id);

//            if (s == null)
//                return null;

//            return new Sale
//            (
//                (int)s.Element("Id")!,
//                (int)s.Element("ProductId")!,
//                (int?)s.Element("MinProductSale"),
//                (double?)s.Element("SumPriceSale"),
//                (bool)s.Element("IfEveryOne")!,
//                (DateTime)s.Element("StartSale")!,
//                (DateTime?)s.Element("EndSale")
//            );
//        }

//        public Sale? Read(Func<Sale, bool> filter)
//        {
//            return ReadAll().FirstOrDefault(filter);
//        }

//        public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
//        {
//            XElement root = XElement.Load(path);
//            var list = root.Elements("Sale").Select(s => new Sale
//            (
//                (int)s.Element("Id")!,
//                (int)s.Element("ProductId")!,
//                (int?)s.Element("MinProductSale"),
//                (double?)s.Element("SumPriceSale"),
//                (bool)s.Element("IfEveryOne")!,
//                (DateTime)s.Element("StartSale")!,
//                (DateTime?)s.Element("EndSale")
//            ));

//            if (filter == null) return list.ToList();
//            return list.Where(filter).ToList();
//        }

//        public void Update(Sale item)
//        {
//            XElement root = XElement.Load(path);

//            XElement? s = root.Elements("Sale").FirstOrDefault(x => (int?)x.Element("Id") == item.Id);

//            if (s == null) return;

//            s.Element("ProductId")!.Value = item.ProductId.ToString();
//            s.Element("MinProductSale")!.Value = item.MinProductSale?.ToString() ?? "";
//            s.Element("SumPriceSale")!.Value = item.SumPriceSale?.ToString() ?? "";
//            s.Element("IfEveryOne")!.Value = item.IfEveryOne.ToString().ToLower();
//            s.Element("StartSale")!.Value = item.StartSale.ToString();
//            s.Element("EndSale")!.Value = item.EndSale?.ToString() ?? "";

//            root.Save(path);
//        }

//        public void Delete(int id)
//        {
//            XElement root = XElement.Load(path);
//            XElement? s = root.Elements("Sale").FirstOrDefault(x => (int?)x.Element("Id") == id);
//            if (s != null)
//            {
//                s.Remove();
//                root.Save(path);
//            }
//        }
//    }
//}





using DalApi;
using Do;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Dal
{
    internal class SaleImplementation : ISale
    {
        // פונקציית עזר למציאת הנתיב המדויק של קובץ המכירות
        private string GetFilePath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo? dir = new DirectoryInfo(baseDir);

            // מטפסים למעלה בתיקיות עד שמוצאים את תיקיית ה-xml המרכזית
            while (dir != null && !Directory.Exists(Path.Combine(dir.FullName, "xml")))
            {
                dir = dir.Parent;
            }

            if (dir == null) throw new DirectoryNotFoundException("xml folder not found!");

            return Path.Combine(dir.FullName, "xml", "sales.xml");
        }

        public int Create(Sale item)
        {
            string path = GetFilePath();
            XElement SaleRoot = XElement.Load(path);
            int id = Config.SaleNum;

            XElement s = new XElement("Sale",
                         new XElement("Id", id),
                         new XElement("ProductId", item.ProductId),
                         new XElement("MinProductSale", item.MinProductSale),
                         new XElement("SumPriceSale", item.SumPriceSale),
                         new XElement("IfEveryOne", item.IfEveryOne),
                         new XElement("StartSale", item.StartSale),
                         new XElement("EndSale", item.EndSale));

            SaleRoot.Add(s);
            SaleRoot.Save(path);
            return id;
        }

        public Sale? Read(int id)
        {
            string path = GetFilePath();
            XElement root = XElement.Load(path);
            XElement? s = root.Elements("Sale").FirstOrDefault(x => (int?)x.Element("Id") == id);

            if (s == null)
                return null;

            return new Sale
            (
                (int)s.Element("Id")!,
                (int)s.Element("ProductId")!,
                (int?)s.Element("MinProductSale"),
                (double?)s.Element("SumPriceSale"),
                (bool)s.Element("IfEveryOne")!,
                (DateTime)s.Element("StartSale")!,
                (DateTime?)s.Element("EndSale")
            );
        }

        public Sale? Read(Func<Sale, bool> filter)
        {
            return ReadAll().FirstOrDefault(filter);
        }

        public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
        {
            string path = GetFilePath();
            XElement root = XElement.Load(path);
            var list = root.Elements("Sale").Select(s => new Sale
            (
                (int)s.Element("Id")!,
                (int)s.Element("ProductId")!,
                (int?)s.Element("MinProductSale"),
                (double?)s.Element("SumPriceSale"),
                (bool)s.Element("IfEveryOne")!,
                (DateTime)s.Element("StartSale")!,
                (DateTime?)s.Element("EndSale")
            ));

            if (filter == null) return list.ToList();
            return list.Where(filter).ToList();
        }

        public void Update(Sale item)
        {
            string path = GetFilePath();
            XElement root = XElement.Load(path);

            XElement? s = root.Elements("Sale").FirstOrDefault(x => (int?)x.Element("Id") == item.Id);

            if (s == null) return;

            s.Element("ProductId")!.Value = item.ProductId.ToString();
            s.Element("MinProductSale")!.Value = item.MinProductSale?.ToString() ?? "";
            s.Element("SumPriceSale")!.Value = item.SumPriceSale?.ToString() ?? "";
            s.Element("IfEveryOne")!.Value = item.IfEveryOne.ToString().ToLower();
            s.Element("StartSale")!.Value = item.StartSale.ToString();
            s.Element("EndSale")!.Value = item.EndSale?.ToString() ?? "";

            root.Save(path);
        }

        public void Delete(int id)
        {
            string path = GetFilePath();
            XElement root = XElement.Load(path);
            XElement? s = root.Elements("Sale").FirstOrDefault(x => (int?)x.Element("Id") == id);
            if (s != null)
            {
                s.Remove();
                root.Save(path);
            }
        }
    }
}