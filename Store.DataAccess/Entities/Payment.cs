using Store.DataAccess.Entities.Base;
using System.Collections.Generic;

namespace Store.DataAccess.Entities
{
    public class Payment : BaseEntity
    {
        public long TransactionId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}