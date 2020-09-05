using Store.BusinessLogic.Models.Base;
using static Store.Shared.Enums.PrintingEdition.Enums;

namespace Store.BusinessLogic.Models.PrintingEditions
{
    public class PrintingEditionModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public Type Type { get; set; }
    }
}
