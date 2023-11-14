using assignment_db.Contexts;
using assignment_db.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace assignment_db.Services;

public class OrderService
{
    private readonly DataContext _context;

    public OrderService(DataContext context)
    {
        _context = context;
    }

    public async Task CreateOrderAsync(CustomerEntity customer, List<(ProductEntity Product, int Quantity)> products)
    {
        try
        {
            var order = new OrderEntity
            {
                Customer = customer,
                OrderRows = products.Select(p => new OrderRowEntity
                {
                    Product = p.Product,
                    Quantity = p.Quantity,
                    Price = p.Product.Price
                }).ToList()
            };

            order.TotalPrice = order.OrderRows.Sum(or => or.Price * or.Quantity);

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }


    public async Task ShowOrdersAsync(CustomerEntity customer)
    {
        try
        {
            var orders = await _context.Orders
                .Where(o => o.CustomerId == customer.Id)
                .ToListAsync();

            Console.WriteLine($"Welcome {customer.FirstName}, these are your current orders!");
            Console.WriteLine("-------------------------------------------------------------");

            foreach (var order in orders)
            {
                Console.WriteLine($"Order Id: {order.Id}");
                Console.WriteLine($"Date of order:{order.OrderDate}");
                Console.WriteLine($"Total sum: {order.TotalPrice}SEK");
                Console.WriteLine("---------------------------------");

                foreach (var orderRow in order.OrderRows)
                {
                    Console.WriteLine($"{orderRow.Quantity}x {orderRow.Product.Name} {orderRow.Price}:-");
                }
            }
            
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public async Task DeleteOrderAsync()
    {
        try
        {

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
