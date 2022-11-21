using ETicaretAPI.Domain.Common;

namespace ETicaretAPI.Domain.Entities;

public class Customer: BaseEntity
{
    public string Name { get; set; }

    #region Relations

    //public ICollection<Order> Orders { get; set; }

    #endregion
}