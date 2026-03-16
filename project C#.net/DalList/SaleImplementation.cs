using DalApi;
using Do;

using System;
using System.Reflection;
using Tools;

namespace Dal
{
internal class SaleImplementation : ISale
{
        public int Create(Sale item)
        {
            int newId = DataSource.Config.NextSaleId;
            Sale copyOfSale = item with { Id = newId };
            DataSource.Sales.Add(copyOfSale);
            LogManager.WriteToLog("Create Sale", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);

            return newId;
        }

        public void Delete(int id)
        {
            var salesToRemove = DataSource.Sales.FirstOrDefault(s=>s.Id==id);
           
            if (salesToRemove != null)
            {
                LogManager.WriteToLog("Delete Sale", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);

                DataSource.Sales.Remove(salesToRemove);
            }
     
            else
            {
                LogManager.WriteToLog("An object of type Sale with such an ID does not exist.", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);

                throw new DalDoesNotExistException("An object of type Sale with such an ID does not exist.");
            }
        }


        public Sale Read(int id)
        {
            LogManager.WriteToLog("Read Sale", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);

            return DataSource.Sales.FirstOrDefault(s => s.Id == id);
            //var sales = DataSource.Sales.Select(s => s.Id == id);
            //foreach (var sale in DataSource.Sales)
            //{
            //    if (sale?.Id == id)
            //    {
            //        return sale;
            //    }
            //}
            LogManager.WriteToLog("Sale with this ID not found", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);

            throw new DalDoesNotExistException("Sale with this ID not found");
        }

        public Sale? Read(Func<Sale, bool> filter)
        {
            // מחפשים בתוך רשימת המוצרים את הראשון שאינו null ועונה על הפילטר
            LogManager.WriteToLog("Read Sale", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);

            return DataSource.Sales.FirstOrDefault(filter);
        }

        public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
        {
            //return new List<Sale>(DataSource.Sales);
            if (filter == null)
            {
                LogManager.WriteToLog("ReadAll Sale", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
                return DataSource.Sales.ToList();

            }
            LogManager.WriteToLog("ReadAll Sale", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);

            return DataSource.Sales.Where(s => s != null && filter(s)).ToList();
        }


        public void Update(Sale item)
        {
               Delete(item.Id);
               DataSource.Sales.Add(item);
            LogManager.WriteToLog("Update Sale", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);

        }

    }
}
