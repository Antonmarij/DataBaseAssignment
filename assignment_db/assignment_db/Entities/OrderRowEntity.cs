using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace assignment_db.Models;

public class OrderRowEntity
{
    public int Quantity { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public int OrderId { get; set; }
    public OrderEntity Order { get; set; } = null!;

    public decimal Price { get; set; }
}
