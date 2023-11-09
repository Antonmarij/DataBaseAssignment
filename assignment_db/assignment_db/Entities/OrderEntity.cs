using System.ComponentModel.DataAnnotations;

namespace assignment_db.Models;

public class OrderEntity
{
    [Key]
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.Now;
    public ICollection<OrderRowEntity> OrderRows { get; set; } = new List<OrderRowEntity>();

}
