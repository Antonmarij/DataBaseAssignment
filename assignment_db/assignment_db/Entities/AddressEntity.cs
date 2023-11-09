using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment_db.Models;

public class AddressEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Street { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(10)")]
    public string PostalCode { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string City { get; set; } = null!;


}
