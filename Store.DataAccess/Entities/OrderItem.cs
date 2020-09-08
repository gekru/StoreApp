using Store.DataAccess.Entities.Base;
using static Store.Shared.Enums.Enums;

namespace Store.DataAccess.Entities
{
    public class OrderItem : BaseEntity
    {
        public int Amount { get; set; }
        public Currency Currency { get; set; }

        public long PrintingEditionId { get; set; }
        public PrintingEdition PrintingEdition { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }

        public int Count { get; set; }
    }
}
