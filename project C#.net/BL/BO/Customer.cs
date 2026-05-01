//using Do;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BO
//{
//    public class Customer
//    {
//        public int ClientId;
//        public string ClientName;
//        public string? Adress;
//        public string? phone;


//        public Customer(int ClientId, string ClientName, string? Adress, string? phone)
//        {
//            this.ClientId = ClientId;
//            this.ClientName = ClientName;
//            this.Adress = Adress;
//            this.phone = phone;
//        }
//        public Customer()
//        {

//        }

//        public override string ToString()
//        {
//            return $"ClientId: {ClientId}, ClientName: {ClientName}, Adress: {Adress}, phone: {phone}";
//        }
//    }
//}





using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        // 1. הוספת השדה עבור חבר המועדון
        public bool IsClubMember;

        // 2. עדכון הבנאי (Constructor) שיקבל גם את המשתנה החדש
        public Customer(int ClientId, string ClientName, string? Adress, string? phone, bool IsClubMember)
        {
            this.ClientId = ClientId;
            this.ClientName = ClientName;
            this.Adress = Adress;
            this.phone = phone;
            this.IsClubMember = IsClubMember;
        }

        public Customer()
        {

        }

        // 3. עדכון ה-ToString כדי שיציג גם את סטטוס המועדון
        public override string ToString()
        {
            return $"ClientId: {ClientId}, ClientName: {ClientName}, Adress: {Adress}, phone: {phone}, IsClubMember: {IsClubMember}";
        }
    }
}