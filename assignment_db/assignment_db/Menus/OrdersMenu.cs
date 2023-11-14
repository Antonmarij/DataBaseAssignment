using assignment_db.Models;
using assignment_db.Services;
using System.Diagnostics;

namespace assignment_db.Menus;

public class OrdersMenu
{
    public static async Task ShowAsync()
    {
        var exit = false;

        try
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1. Create an Order");
                Console.WriteLine("2. Show all Orders");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("0. Go Back");
                Console.Write("Choose an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        await CreateOrderAsync();
                        break;

                    case "2":
                        await ShowOrdersAsync();
                        break;

                    case "3":
                        await EditOrderAsync();
                        break;

                    case "0":
                        await MenuService.ShowAsync();
                        break;

                    default:
                        Console.WriteLine("Invalid option, choose one of the above.");
                        break;
                }
                Console.ReadKey();
            }
            while (!exit);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public static async Task CreateOrderAsync()
    {
        try
        {
            var order = new OrderEntity();
            Console.Clear();
            Console.WriteLine("Create your order!");
            Console.WriteLine("------------------");
            Console.Write("");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public static async Task ShowOrdersAsync()
    {

    }

    public static async Task EditOrderAsync()
    {

    }
}
