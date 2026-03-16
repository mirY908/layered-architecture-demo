
using Do;
using DalApi;

namespace DalTest;

public static class Initialization
{
    private static IDal s_Dal;

    public static List<int> productCodes = new List<int>();
    /// <summary>
    /// יצירת רשימה של המוצר
    /// </summary>
    private static void createProducts()
    {
        s_Dal.Product.Create(new Product(0, "פיצה איטלקית", Category.Piza, 57, 10));
        s_Dal.Product.Create(new Product(0, "סלט יווני", Category.Salad, 23, 12));
        s_Dal.Product.Create(new Product(0, "פסטה מוקרמת ", Category.Pasta, 40, 8));
        s_Dal.Product.Create(new Product(0, "הום פרייז ", Category.HomeFrize, 42, 6));
        s_Dal.Product.Create(new Product(0, "שתיה", Category.Beverage, 10, 23));
    }
    /// <summary>
    /// יצירת רשימת מבצע
    /// </summary>
    private static void createSales()
    {
  
        s_Dal.Sale.Create(new Sale(0, 112, 10,32.5,false,DateTime.Now,DateTime.Now));
        s_Dal.Sale.Create(new Sale(0, 113, 10, 32.5,true , DateTime.Now, DateTime.Now));
        s_Dal.Sale.Create(new Sale(0, 114, 10, 32.5, true, DateTime.Now, DateTime.Now));
        s_Dal.Sale.Create(new Sale(0, 115, 10, 32.5, false, DateTime.Now, DateTime.Now));
        s_Dal.Sale.Create(new Sale(0, 116, 10, 32.5, true, DateTime.Now, DateTime.Now));
    }
    /// <summary>
    /// יצירת רשימת לקוח
    /// </summary>
    private static void createCustumer()
    {
        s_Dal.Custemer.Create(new Custemer(122, "Yael", "jerusalem", "0504447777"));
        s_Dal.Custemer.Create(new Custemer(133, "Rachel", "Bb", "0504447771"));
        s_Dal.Custemer.Create(new Custemer(144, "Yosef", "usa", "0504447773"));
        s_Dal.Custemer.Create(new Custemer(155, "Yisrael", "Yisrael", "0504447775"));
        s_Dal.Custemer.Create(new Custemer(166, "Rfael", "jerusalem", "0504447779"));
    }



    public static void Initialize()
    {
        s_Dal = DalApi.Factory.Get;
        createProducts();
        createSales();
        createCustumer();

    }

    //internal static void Initialize()
    //{
    //    throw new NotImplementedException();
    //}
}
