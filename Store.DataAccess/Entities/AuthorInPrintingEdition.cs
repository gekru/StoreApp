using Store.DataAccess.Entities.Base;

namespace Store.DataAccess.Entities
{
    public class AuthorInPrintingEdition : BaseEntity
    {
        public long AuthorId { get; set; }
        public Author Author { get; set; }

        public long PrintingEditionId { get; set; }
        public PrintingEdition PrintingEdition { get; set; }
    }
}
