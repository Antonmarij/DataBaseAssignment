using assignment_db.Contexts;
using assignment_db.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace assignment_db.Services;

public class CustomerService
{
    private readonly DataContext _context;

    public CustomerService(DataContext context)
    {
        _context = context;
    }

    public async Task CreateCustomerAsync(CustomerEntity customer)
    {
        try
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
           
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public async Task<List<CustomerEntity>> GetAllAsync()
    {
        try
        {
            List<CustomerEntity> customers = await _context.Customers.ToListAsync();
            return customers;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
}
