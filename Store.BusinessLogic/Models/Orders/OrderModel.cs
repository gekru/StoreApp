using Store.BusinessLogic.Models.Base;
using Store.BusinessLogic.Models.Users;
using System.Collections.Generic;
using static Store.Shared.Enums.Enums;

namespace Store.BusinessLogic.Models.Orders
{
    public class OrderModel : BaseModel
    {
        public string Description { get; set; }
        public OrderStatus Status { get; set; }
        public UserModel User { get; set; }
        public ICollection<OrderItemModel> MyProperty { get; set; }
    }
}
