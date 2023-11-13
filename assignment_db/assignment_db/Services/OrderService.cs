using assignment_db.Contexts;
using assignment_db.Models;

namespace assignment_db.Services;

public class OrderService
{
    private readonly DataContext _context;

    public OrderService(DataContext context)
    {
        _context = context;
    }

    public async Task CreateOrderAsync(OrderEntity order)
    {

    }
}
