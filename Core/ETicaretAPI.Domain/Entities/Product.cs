using ETicaretAPI.Domain.Common;

namespace ETicaretAPI.Domain.Entities;

public class Product: BaseEntity
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }

    #region Relations

    public ICollection<Order> Orders { get; set; }

    #endregion
    
}
