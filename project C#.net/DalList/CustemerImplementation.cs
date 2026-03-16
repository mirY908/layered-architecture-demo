using DalApi;
using Do;
using System.Reflection;
using Tools;

namespace Dal
{
    internal class CustemerImplementation : ICustomer
    {


        public int Create(Custemer item)
        {
            var custemerToRemove = DataSource.Customers.FirstOrDefault(c => item.CustemerId == c.CustemerId);
            if (custemerToRemove != null) 
            {
                LogManager.WriteToLog("create customer", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
                throw new DalAlreadyExistsException("An object of type Custemer with such an ID already exists.");
            }
            //foreach (var customer in DataSource.Customers)
            //{
            //    if (item.CustemerId == customer?.CustemerId)
            //    {
            //        throw new DalAlreadyExistsException("An object of type Custemer with such an ID already exists.");
            //    }
            //}

            DataSource.Customers.Add(item);
            LogManager.WriteToLog("create customer", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
            return item.CustemerId;
        }

        public void Delete(int id)
        {
            LogManager.WriteToLog("Cannot delete this object", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);

            throw new DalAlreadyExistsException("Cannot delete this object");
        }
        public Custemer? Read(Func<Custemer, bool> filter)
        {
            if (DataSource.Customers == null) return null;
            LogManager.WriteToLog("Read customer", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);

            return DataSource.Customers.FirstOrDefault(filter);
        }
        public Custemer? Read(int id)
        {
            LogManager.WriteToLog("Read customer", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);

            return DataSource.Customers.FirstOrDefault(c => c != null && c.CustemerId == id);
            //throw new DalDoesNotExistException("An object of type Custemer with such an ID does not exist.");
        }






        public List<Custemer> ReadAll(Func<Custemer, bool>? filter = null)
        {
           if (filter == null)
            {
                LogManager.WriteToLog("ReadAll customer", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
                return DataSource.Customers.Select(c => c).ToList();
            }
            LogManager.WriteToLog("ReadAll customer", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
            return DataSource.Customers.Where(c => c != null && filter(c)).ToList();
        }


        public void Update(Custemer item)
        {
           // Custemer existingCustomer = null;
            var existingCustomer = DataSource.Customers.FirstOrDefault(c => item.CustemerId == c.CustemerId);

            if (existingCustomer != null)
            {
                DataSource.Customers.Remove(existingCustomer);
                DataSource.Customers.Add(item);
            }
            else
            {
                LogManager.WriteToLog("Update customer", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
                throw new DalDoesNotExistException("An object of type Custemer with such an ID does not exist.");
            }
        }
    }
}
