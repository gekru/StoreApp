using Store.BusinessLogic.Models.Base;
using static Store.Shared.Enums.Enums;

namespace Store.BusinessLogic.Models.Payments
{
    public class PaymentModel : BaseModel
    {
        public int Amount { get; set; }
        public string UserEmail { get; set; }
        public string StripeToken { get; set; }
        public string Description { get; set; }
        public Currency Currency { get; set; }
    }
}
