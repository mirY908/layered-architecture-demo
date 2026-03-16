using DalApi;
using Do;
using System.Reflection;
using Tools;

namespace Dal
{
internal class ProductImplementation : IProduct
{


        public int Create(Product item)
        {
            int newId = DataSource.Config.NextPrductId;
            Product copyOfProduct = item with { Id = newId };
            DataSource.Products.Add(copyOfProduct);
            LogManager.WriteToLog("create Product", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
            return newId;
        }

 

        public void Delete(int id)
        {
           // Product productToRemove = null;
            var productToRemove = DataSource.Products.FirstOrDefault(p => p.Id == id);

            //foreach (var product in DataSource.Products)
            //{
            //    if (product?.Id == id)
            //    {
            //        productToRemove = product;
            //        break; // Exit the loop once we find the product
            //    }
            //}

            if (productToRemove != null)
            {
                LogManager.WriteToLog("Delete Product", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);

                DataSource.Products.Remove(productToRemove);
            }
            else
            {
                LogManager.WriteToLog("An Product of type Product with such an ID does not exist.", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);

                throw new DalDoesNotExistException("An object of type Product with such an ID does not exist.");
            }
        }


        public Product? Read(int id)
        {
            //var product = DataSource.Products.Select(p => p.Id == id);
            //foreach (var product in DataSource.Products)
            //{
            //    if (product?.Id == id)
            //    {
            //        return product;
            //    }
            //}
            //return null;
            LogManager.WriteToLog("Read Product", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);

            return DataSource.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product? Read(Func<Product, bool> filter)
        {
            // מחפשים בתוך רשימת המוצרים את הראשון שאינו null ועונה על הפילטר
            LogManager.WriteToLog("Read Product", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);

            return DataSource.Products.FirstOrDefault(filter);
        }

        //public List<Product> ReadAll(Func<Product, bool>? filter = null)
        public List<Product?> ReadAll(Func<Product, bool>? filter = null)
        {
            //return new List<Sale>(DataSource.Sales);
            if (filter == null)
            {
                LogManager.WriteToLog("ReadAll Product", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
                return DataSource.Products.Select(p => p).ToList();

            }
            LogManager.WriteToLog("ReadAll Product", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);

            return DataSource.Products.Where(p => p != null && filter(p)).ToList();
        }


        public void Update(Product item)
        {          

            Delete(item.Id);
            DataSource.Products.Add(item);
            LogManager.WriteToLog("Update Product", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);

        }

        //List<Product?> ICrud<Product>.ReadAll(Func<Product, bool>? filter)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
