using System.Text.Json.Serialization;
using ETicaretAPI.Domain.Common;

namespace ETicaretAPI.Domain.Entities;

public class Order: BaseEntity
{
    public Guid CustometId { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }

    #region Relations

    public ICollection<Product> Products { get; set; }
    public Customer Customer { get; set; }
    public Basket Basket { get; set; }

    #endregion
}