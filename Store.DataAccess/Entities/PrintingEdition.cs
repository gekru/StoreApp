using Store.DataAccess.Entities.Base;
using System.Collections.Generic;
using static Store.Shared.Enums.Enums;

namespace Store.DataAccess.Entities
{
    public class PrintingEdition : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public PrintingEditionType Type { get; set; }

        public ICollection<AuthorInPrintingEdition> AuthorInPrintingEdition { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
