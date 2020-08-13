using System;
using System.Collections.Generic;
using Store.DataAccess.Entities.Base;

namespace Store.DataAccess.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public long ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }

        public long PaymentId { get; set; }
        public Payment Payment { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
