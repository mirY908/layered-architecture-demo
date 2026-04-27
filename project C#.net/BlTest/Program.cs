using BlApi;
using BO;

namespace BITest;

internal class Program
{
    // הגדרת שדה עבור הממשק הראשי של השכבה הלוגית IBl כנדרש בדף
    static readonly IBI s_bl = Factory.Get();

    static void Main(string[] args)
    {
        try
        {
            // קריאה לפונקציית האתחול מה-DAL כדי לחסוך זמן בהקלדת נתונים
            DalTest.Initialization.Initialize();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Initialization failed: {ex.Message}");
        }

        Console.WriteLine("--- Welcome to the Business Logic Testing Tool ---");

        int choice;
        do
        {
            Console.WriteLine("\nChoose an entity to test:");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Product");
            Console.WriteLine("2: Customer");
            Console.WriteLine("3: Order / Sales");

            if (!int.TryParse(Console.ReadLine(), out choice)) choice = -1;

            try
            {
                switch (choice)
                {
                    case 1: ProductTest(); break;
                    case 2: CustomerTest(); break;
                    case 3: OrderTest(); break;
                    case 0: Console.WriteLine("Exiting... Bye!"); break;
                    default: Console.WriteLine("Invalid choice!"); break;
                }
            }
            catch (Exception ex)
            {
                // תפיסת חריגות מה-BL כפי שנדרש בדף ההנחיות
                Console.WriteLine($"[ERROR]: {ex.Message}");
            }
        } while (choice != 0);
    }

    // --- בדיקות מוצרים ---
    static void ProductTest()
    {
        Console.WriteLine(@"Product Actions:
1: View all products
2: View product by ID");

        string sub = Console.ReadLine();
        if (sub == "1")
        {
            var all = s_bl.product.ReadAll();
            foreach (var p in all) Console.WriteLine(p);
        }
        else if (sub == "2")
        {
            Console.WriteLine("Enter Product ID:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(s_bl.product.Read(id));
        }
    }

    // --- בדיקות לקוחות ---
    static void CustomerTest()
    {
        Console.WriteLine(@"Customer Actions:
1: View all customers
2: View customer by ID");

        string sub = Console.ReadLine();
        if (sub == "1")
        {
            var all = s_bl.Castumer.ReadAll();
            foreach (var c in all) Console.WriteLine(c);
        }
        else if (sub == "2")
        {
            Console.WriteLine("Enter Customer ID:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(s_bl.Castumer.Read(id));
        }
    }

    // --- בדיקות הזמנות (החלק המעניין!) ---
    static void OrderTest()
    {
        Console.WriteLine(@"Order Actions:
1: View all orders
2: Add Product to Order (Calculates Sales)");

        string sub = Console.ReadLine();
        if (sub == "1")
        {
            var all = s_bl.order.ReadAll();
            foreach (var o in all) Console.WriteLine(o);
        }
        else if (sub == "2")
        {
            Console.WriteLine("Enter Product ID:");
            int pId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Amount:");
            int amount = int.Parse(Console.ReadLine());

            // כאן המערכת מחשבת אילו מבצעים קיימים למוצר הזה
            var sales = s_bl.order.AddProductToOrder(pId, amount);
            Console.WriteLine("Applicable Sales for this product:");
            foreach (var s in sales) Console.WriteLine($"- Sale ID: {s.id}, Best Price: {s.price}");
        }
    }
}