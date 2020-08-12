using System;

namespace Store.DataAccess.Entities
{
    public class AuthorInPrintingEdition
    {
        public long AuthorId { get; set; }
        public Author Author { get; set; }

        public long PrintingEditionId { get; set; }
        public PrintingEdition PrintingEdition { get; set; }

        public DateTime Date { get; set; }
    }
}
