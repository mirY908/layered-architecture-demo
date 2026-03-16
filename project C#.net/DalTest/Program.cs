using DalApi;
using DalTest;
using Do;
using Tools;
using System.Reflection;

internal class Program
{
    private static readonly IDal s_Dal = DalApi.Factory.Get;
    
    /// <summary>
    /// הפעלת התוכנה 
    /// בחירת יישות
    /// </summary>
    static void Main(string[] args)
    {
        Console.WriteLine("Do you want to initialize data? (y/n)");
        string ans = Console.ReadLine();
        if (ans == "y")
        {
            Initialization.Initialize();
        }
        try
        {
            int select1 = PrintMainMenu();
            while (select1 != 0)
            {
                switch (select1)
                {
                    case 1:
                        Console.WriteLine("Product");
                        ProductMenu();
                        break;
                    case 2:
                        Console.WriteLine("Sale");
                        SaleMenu();
                        break;
                    case 3:
                        Console.WriteLine("Custemer");
                        CustemerMenu();
                        break;

                    case 4:
                        Console.WriteLine("Custemer");
                        LogManager.DeleteOldFolder();
                        break;

                    case 0:
                        Console.WriteLine("exist");

                        break;
                    default:
                        Console.WriteLine("Wrong selection please select again");
                        break;
                }

                select1 = PrintMainMenu();
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }

    /// <summary>
    /// בחירה בתוך המוצר איזה פונקציה רוצים להפעיל
    /// </summary>
    private static void ProductMenu()
    {

        int select = PrintSubMenue("Product");

        while (select != 0)
        {

            switch (select)
            {
                case 1:
                    ReadAll<Product>(s_Dal.Product);
                    break;
                case 2:
                    Read<Product>(s_Dal.Product);
                    break;
                case 3:
                    AddProduct();
                    break;
                case 4:
                    Delete<Product>(s_Dal.Product);
                    break;
                case 5:
                    UpdateProduct();
                    break;
                default:
                    Console.WriteLine("wrong selection! please press again!");
                    break;
            }
            select = PrintSubMenue("Product");
        }
    }
    /// <summary>
    /// בחירה בתוך מבצע איזה פונקציה רוצים להפעיל
    /// </summary>
    private static void SaleMenu()
    {
        int select = PrintSubMenue("Sale");
        while (select != 0)
        {
            switch (select)
            {
                case 1:
                    ReadAll<Sale>(s_Dal.Sale);
                    break;
                case 2:
                    Read<Sale>(s_Dal.Sale);
                    break;
                case 3:
                    AddSale();
                    break;
                case 4:
                    Delete<Sale>(s_Dal.Sale);
                    break;
                case 5:
                    UpdateSale();
                    break;
                default:
                    Console.WriteLine("wrong selection! please press again!");
                    break;
            }
            select = PrintSubMenue("Sale");
        }
    }
    /// <summary>
    /// בחירה בתוך לקוח איזה פונקציה רוצים להפעיל
    /// </summary>
    private static void CustemerMenu()
    {
        int select = PrintSubMenue("Custemer");
        while (select != 0)
        {
            switch (select)
            {
                case 1:
                    ReadAll<Custemer>(s_Dal.Custemer);
                    break;
                case 2:
                    Read<Custemer>(s_Dal.Custemer);
                    break;
                case 3:
                    AddCustumer();
                    break;
                case 4:
                    Delete<Custemer>(s_Dal.Custemer);
                    break;
                case 5:
                    UpdateCustumer();
                    break;
                default:
                    Console.WriteLine("wrong selection! please press again!");
                    break;
            }
            select = PrintSubMenue("Custemer");
        }
    }

    /// <summary>
    /// קבלת כל הנתונים על המוצר
    /// </summary>
    /// <param name="productName"></param>
    /// <returns></returns>

    private static Product AskProduct(int code=0)
    {
        string name;
        Category category;
        double price;
        int count;

        Console.WriteLine("Enter product name");
        name = Console.ReadLine();
        Console.WriteLine("Enter category :between 0 to 5");
        int cat;
        if (!int.TryParse(Console.ReadLine(), out cat)) category = 0;
        else
            category = (Category)cat;
        Console.WriteLine("Enter price");
        if (!double.TryParse(Console.ReadLine(), out price)) price = 10;
        Console.WriteLine("Enter count in stock");
        if (!int.TryParse(Console.ReadLine(), out count)) count = 0;
        return new Product(code, name, category, price, count);
    }
    /// <summary>
    /// קבלת פרטי מבצע
    /// </summary>
    /// <param ProductId="code"></param>
    /// <returns></returns>
    private static Sale AskSale(int code=0)
    {
        int Id=0;
        int ProductId;
        int? MinProductSale;
        bool IfEveryOne;
        DateTime DateStartSale;
        double? SumPriceSale;
        DateTime? DateEndSale = null;

        Console.WriteLine("insert id");
        Id=int.Parse(Console.ReadLine());
        code = Id;


        int select;
        ProductId = code;
        Console.WriteLine("Enter ProductId");
        if (!int.TryParse(Console.ReadLine(), out ProductId)) ProductId = 0;

        Console.WriteLine("For all the custumers enter 0 or 1");
        if (!int.TryParse(Console.ReadLine(), out select)) select = 1;
        IfEveryOne = select == 1;
       // PriceSale = 0;

        Console.WriteLine("Enter MinProductSale ");
        //if (!int.TryParse(Console.ReadLine(), out MinProductSale)) MinProductSale = 0;


        int minProductSaleValue;
        if (!int.TryParse(Console.ReadLine(), out minProductSaleValue))
        {
            minProductSaleValue = 0;
        }
        MinProductSale = minProductSaleValue; 




        Console.WriteLine("Enter SumPriceSale");
        SumPriceSale = double.Parse(Console.ReadLine());
        
        DateStartSale = DateTime.Now.AddDays(select);
        Console.WriteLine("Enter date and sale");
        if (!int.TryParse(Console.ReadLine(), out select)) select = 0;
        DateEndSale = DateStartSale.AddDays(select);
        return new Sale(Id, ProductId, MinProductSale, SumPriceSale, IfEveryOne, DateStartSale, DateEndSale);


      
    }
    /// <summary>
    /// קבלת פרטי לקוח
    /// </summary>
    /// <param name="identity"></param>
    /// <returns></returns>
    private static Custemer AskCustemer(int identity)
    {
        int CustomerId;
        string CustomerAddress;
        string CustomerPhone;
        string? CustomerName = null;
            CustomerId = identity;
        Console.WriteLine("Enter customer name");
        CustomerName = Console.ReadLine();
        Console.WriteLine("Enter customer address");
        CustomerAddress = Console.ReadLine();
        Console.WriteLine("Enter customer phone");
        CustomerPhone = Console.ReadLine();
        return new Custemer(CustomerId, CustomerName, CustomerAddress, CustomerPhone);
    }

    /// <summary>
    /// קבלת קוד למוצר חדש שליחה לפונקציה לקבלת פרטים על המוצר והוספת המוצר החדש
    /// </summary>
    private static void AddProduct()
    {
        try
        {
           // Console.WriteLine("insert code");
           // int code1 = int.Parse(Console.ReadLine());
            Product p = AskProduct();
            int code = s_Dal.Product.Create(p);
            p = p with { Id = code };
            Console.WriteLine("The product added successfuly!");
        }
        catch (Exception ex)
        {
            //////
            Console.WriteLine(ex.Message);
        }

    }
    /// <summary>
    /// הכנסת קוד מבצע
    /// שליחה לפונקציה לקבלת פרטי מבצע
    /// הוספת המבצע החדש
    /// </summary>
    private static void AddSale()
    {
        try
        {
            //Console.WriteLine("insert code");
            //int code1=int.Parse(Console.ReadLine());
            Sale s = AskSale();
            int code = s_Dal.Sale.Create(s);
            s = s with { Id = code };
            Console.WriteLine("the product added to sele successfuly!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    /// <summary>
    /// הכנסת קוד 
    /// שליחה לפונקציה לקבלת פרטי לקוח
    /// יצירת הלקוח החדש
    /// </summary>
    private static void AddCustumer()
    {
        try
        {
            Console.WriteLine("Enter code");
            int code=int.Parse(Console.ReadLine());
            Custemer c = AskCustemer(code);
            s_Dal.Custemer.Create(c);
            Console.WriteLine("the product added to sele successfuly!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

    /// <summary>
    /// קבלת קוד מוצר
    /// עדכון מוצר זה
    /// </summary>
    private static void UpdateProduct()
    {
        try
        {
            int code;
            Console.WriteLine("Enter product code");
            code=int.Parse(Console.ReadLine());
            Product p = AskProduct(code);
            s_Dal.Product.Update(p);
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
    }
    /// <summary>
    /// קבלת קוד מבצע
    /// קבלת פרטים לשינוי המבצע
    /// עדכון המבצע
    /// </summary>
    private static void UpdateSale()
    {
        //Sale s = AskSale();
        //int code = s_Dal.Sale.Update();
        // s = s with { Id = code };
        //Console.WriteLine("The product added successfuly!");

        try
        {
            int code=0;
         // Console.WriteLine("Enter Sale id");
           // if (!int.TryParse(Console.ReadLine(), out code))
             //   code = 0;
            Sale s = AskSale(code);
            s_Dal.Sale.Update(s);
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
    }
    /// <summary>
    /// קבלת קוד לקוח
    /// שליחה לפונקצית קבלת הפרטים בחדשים
    /// עדכון לקוח
    /// </summary>
    private static void UpdateCustumer()
    {
        try
        {
           Console.WriteLine("Enter Custumer id");
            int code=int.Parse(Console.ReadLine());
            Custemer c = AskCustemer(code);
            s_Dal.Custemer.Update(c);
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
    }

    /// <summary>
    /// מעבר בלולאה על היישות והדפסה של כל יישות
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="icrud"></param>
    private static void ReadAll<T>(ICrud<T> icrud)
    {
        foreach (var item in icrud.ReadAll())
            Console.WriteLine(item);
    }
    /// <summary>
    /// הדפסת היישות 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="icrud"></param>
    private static void Read<T>(ICrud<T> icrud)
    {
        try
        {
            Console.WriteLine("Enter Code");
            int code = int.Parse(Console.ReadLine());
            Console.WriteLine(icrud.Read(code));
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
    }
    /// קבלת יישות ומחיקתה
    private static void Delete<T>(ICrud<T> icrud)
    {
        try
        {
            int code;
             Console.WriteLine("Enter code");
            if (!int.TryParse(Console.ReadLine(), out code))
               code = -1;
             icrud.Delete(code);

        }
        catch (Exception e) { Console.WriteLine(e.Message); }
    }
    /// <summary>
    /// תפריט לבחירת יישות
    /// </summary>
    /// <returns></returns>
    public static int PrintMainMenu()
    {
        Console.WriteLine("for Product press 1");
        Console.WriteLine("for Sale press 2");
        Console.WriteLine("for Custumer press 3");
        Console.WriteLine("to delete all log files press 4");
        Console.WriteLine("To exist press 0");
        int select = 0;
        select = int.Parse(Console.ReadLine());
        return select;
    }
    /// <summary>
    /// תפריט לבחירת פונקציה
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static int PrintSubMenue(string item)
    {
        Console.WriteLine($"To read all {item} press 1");
        Console.WriteLine($"To read one {item} press 2");
        Console.WriteLine($"To add {item} press 3");
        Console.WriteLine($"To delete {item} press 4");
        Console.WriteLine($"To update {item} press 5");
        Console.WriteLine("To go back press 0");
        int select;
        select = int.Parse(Console.ReadLine());
        return select;

    }



}
