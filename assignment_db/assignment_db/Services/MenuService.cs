using System.Diagnostics;

namespace assignment_db.Services;

public class MenuService
{
    public bool hasSignedUp = false;

    public void DisplayMenu()
    {
        if (!hasSignedUp)
        {
            SignUpMenu();
            hasSignedUp = true;
        }

        MainMenu();
    }

    public static void SignUpMenu()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Welcome! Please create a profile!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

    }




    public static void MainMenu()
    {
        var exit = false;

        try
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1. Place an order");
                Console.WriteLine("2. View orders");
                Console.WriteLine("3. Manage orders");
                Console.WriteLine("0. Exit");
                var option = Console.ReadLine();

                Console.Clear();

                switch (option)
                {
                    case "1":
                        CreateOrderMenu();
                        break;

                    case "2":
                        ViewOrderMenu();
                        break;

                    case "3":
                        ManageOrderMenu();
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
