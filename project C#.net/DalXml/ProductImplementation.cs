using DalApi;
using Do; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Dal
{
    internal class ProductImplementation : IProduct
    {
        //string path = @"..\xml\products.xml";
        string path = @"xml\products.xml";

        public int Create(Product item)
        {
            XElement productRoot = XElement.Load(path);

            int id = Config.ProductNum;

            XElement p = new XElement("Product",
                new XElement("ProductId", id),
                new XElement("ProductName", item.ProductName),
                new XElement("Category", item.Category),
                new XElement("Price", item.Price), 
                new XElement("Amount", item.Amount));

            productRoot.Add(p);
            productRoot.Save(path);
            return id;
        }

        public Product? Read(int id)
        {
            XElement root = XElement.Load(path);
            XElement? p = root.Elements("Product").FirstOrDefault(x => (int?)x.Element("ProductId") == id);

            if (p == null)
                return null;

            return new Product
            {
                Id = (int)p.Element("ProductId")!,
                ProductName = (string)p.Element("ProductName")!,
                Category = (Category)Enum.Parse(typeof(Category), (string)p.Element("Category")!),
                Price = (double)p.Element("Price")!,
                Amount = (int?)p.Element("Amount")   
            };
        }

        public Product? Read(Func<Product, bool> filter)
        {
            return ReadAll().FirstOrDefault(filter);
        }

        public List<Product> ReadAll(Func<Product, bool>? filter = null)
        {
            XElement root = XElement.Load(path);

            var list = root.Elements("Product").Select(p => new Product
            {
                Id = (int)p.Element("ProductId")!,
                ProductName = (string)p.Element("ProductName")!,
                Category = (Category)Enum.Parse(typeof(Category), (string)p.Element("Category")!),
                Price = (double)p.Element("Price")!,
                Amount = (int?)p.Element("Amount")
            });

            if (filter == null) return list.ToList();
            return list.Where(filter).ToList();
        }

        public void Update(Product item)
        {
            XElement root = XElement.Load(path);
            XElement? p = root.Elements("Product").FirstOrDefault(x => (int?)x.Element("ProductId") == item.Id);

            if (p == null) return;

            p.Element("ProductName")!.Value = item.ProductName;
            p.Element("Category")!.Value = item.Category.ToString();
            p.Element("Price")!.Value = item.Price.ToString();
            p.Element("Amount")!.Value = item.Amount?.ToString() ?? "";

            root.Save(path);
        }

        public void Delete(int id)
        {
            XElement root = XElement.Load(path);
            XElement? p = root.Elements("Product").FirstOrDefault(x => (int?)x.Element("ProductId") == id);

            if (p != null)
            {
                p.Remove();
                root.Save(path);
            }
        }
    }
}
