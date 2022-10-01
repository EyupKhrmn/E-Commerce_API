using System.ComponentModel.DataAnnotations;

namespace ETicaretAPI.Domain.Common;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
}