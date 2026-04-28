

using BO;

namespace BlApi
{   
    public interface ICastumer
        {
            int Create(Customer item);
             Customer? Read(int id);
             Customer? Read(Func<Customer, bool> filter);
            IEnumerable<Customer?> ReadAll(Func<Customer, bool>? filter = null);
            void Update(Customer item);
       
            void Delete(int id);
            public bool IsCustomerExist();
         }


}

 


