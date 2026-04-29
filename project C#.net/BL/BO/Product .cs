using Do;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Product
    {
        public int Id;
        public string ProductName;
        public  Category category;
        public double Price;
        public int Amount;
        public List<SaleInProduct> SaleInProducts;
        public Product(int Id, string ProductName, Category Category, double Price, int Amount)
        {
            this.Id = Id;
            this.ProductName = ProductName;
            this.category = Category;
            this.Price = Price;
            this.Amount = Amount;
           // this.SaleInProducts = saleInProducts;
        }
        public Product()
        {
            
        }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {ProductName}, Category: {category}, Price: {Price}, Amount: {Amount}";
        }
    }
}
