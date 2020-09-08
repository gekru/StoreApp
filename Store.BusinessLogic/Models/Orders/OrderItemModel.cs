using Store.BusinessLogic.Models.Base;
using Store.BusinessLogic.Models.PrintingEditions;
using static Store.Shared.Enums.PrintingEdition.Enums;

namespace Store.BusinessLogic.Models.Orders
{
    public class OrderItemModel : BaseModel
    {
        public int Amount { get; set; }
        public Currency Currency { get; set; }
        public PrintingEditionModel PrintingEdition { get; set; }
        public OrderModel Order { get; set; }
        public int Count { get; set; }
    }
}
