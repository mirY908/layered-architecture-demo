
using Do;
namespace Dal
{
    internal static class DataSource
    {
        internal static List<Product?> Products = new List<Product?>(50);

        internal static List<Custemer?> Customers = new List<Custemer?>(100);

        internal static List<Sale?> Sales = new List<Sale?>(20);


        public static void add()
        {

        }


        internal static class Config
        {
            //Sale
            internal const int StartSaleId = 15;

            //internal const int StartProductId = StartSaleId;
            private static int nextSaleId = StartSaleId;

            internal static int NextSaleId
            {
                get
                {
                    return nextSaleId++;
                }
            }



            //prduct
            internal const int StartPrductId = 100;

            //internal const int StartProductId = StartSaleId;
            private static int nextPrductId = StartPrductId;

            internal static int NextPrductId
            {
                get
                {
                    return nextPrductId++;
                }
            }


        }
    }
}
