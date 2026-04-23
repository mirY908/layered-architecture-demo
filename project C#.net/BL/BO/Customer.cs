using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Customer
    {
        public int ClientId;
        public string ClientName;
        public string? Adress;
        public string? phone;

        public Customer(int ClientId, string ClientName, string? Adress, string? phone)
        {
            this.ClientId = ClientId;
            this.ClientName = ClientName;
            this.Adress = Adress;
            this.phone = phone;
        }
        public Customer()
        {
            
        }
    }
}
