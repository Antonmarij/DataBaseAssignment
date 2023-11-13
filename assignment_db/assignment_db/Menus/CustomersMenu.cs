using assignment_db.Contexts;
using assignment_db.Models;
using assignment_db.Services;
using System.Diagnostics;

namespace assignment_db.Menus;

public class CustomersMenu
{

    private static readonly DataContext dataContext = new DataContext();
    private static readonly CustomerService customerService = new CustomerService(dataContext);



    public static async Task ShowAsync()
    {
        var exit = false;

        try
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1. Create Customer");
                Console.WriteLine("2. Show All Customers");
                Console.WriteLine("0. Go Back");
                Console.Write("Choose an option: ");
                var option = Console.ReadLine();

                Console.Clear();

                switch (option)
                {
                    case "1":
                        await CreateCustomerAsync();
                        break;

                    case "2":
                        await ShowAllCustomers();
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
            while (exit == false);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }


    public static async Task CreateCustomerAsync()
    {
        try
        {
            var customer = new CustomerEntity();
            Console.Clear();
            Console.WriteLine("Create Customer:");
            Console.WriteLine("----------------");
            Console.Write("Enter first name: ");
            customer.FirstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            customer.LastName = Console.ReadLine();

            Console.Write("Enter email: ");
            customer.Email = Console.ReadLine();

            await customerService.CreateCustomerAsync(customer);

            Console.WriteLine("Customer created!");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    //doesnt return anything?
    public static async Task ShowAllCustomers()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("All Customers:");
            Console.WriteLine("--------------");

            var customers = await customerService.GetAllAsync();

            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine($"{customer.Id}\n{customer.FirstName} {customer.LastName}");
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
