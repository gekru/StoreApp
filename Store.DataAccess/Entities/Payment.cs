using Store.DataAccess.Entities.Base;
using System.Collections.Generic;

namespace Store.DataAccess.Entities
{
    public class Payment : BaseEntity
    {
        public ICollection<Order> Orders{ get; set; }
    }
}
