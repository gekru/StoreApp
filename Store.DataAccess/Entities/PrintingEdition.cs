using Store.DataAccess.Entities.Base;
using Store.Shared.Enums.PrintingEdition;
using System.Collections.Generic;

namespace Store.DataAccess.Entities
{
    public class PrintingEdition : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public Type Type { get; set; }

        public ICollection<AuthorInPrintingEdition> AuthorInPrintingEdition { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
