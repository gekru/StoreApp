using Store.BusinessLogic.Models.Base;
using Store.BusinessLogic.Models.Users;
using System.Collections;
using System.Collections.Generic;
using static Store.Shared.Enums.Order.Enums;

namespace Store.BusinessLogic.Models.Orders
{
    public class OrderModel : BaseModel
    {
        public string Description { get; set; }
        public Status Status { get; set; }
        public UserModel User { get; set; }
        public ICollection<OrderItemModel> MyProperty { get; set; }
    }
}
