using assignment_db.Menus;
using System.Diagnostics;

namespace assignment_db.Services;

public class MenuService
{
    


    public static async Task ShowAsync()
    {
        var exit = false;

        try
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1. Go To Orders");
                Console.WriteLine("2. Go To Products");
                Console.WriteLine("3. Go To Customers");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                var option = Console.ReadLine();



                switch (option)
                {
                    case "1":
                        await OrdersMenu.ShowAsync();
                        break;

                    case "2":
                        await ProductsMenu.ShowAsync();
                        break;

                    case "3":
                        await CustomersMenu.ShowAsync();
                        break;

                    case "0":
                        exit = true;
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option, choose one of the above.");
                        break;
                }
                Console.ReadKey();
            }
            while (exit == false);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
