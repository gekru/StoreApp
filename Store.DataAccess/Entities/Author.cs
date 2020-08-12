using System.Collections.Generic;
using Store.DataAccess.Entities.Base;

namespace Store.DataAccess.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<AuthorInPrintingEdition> AuthorInPrintingEditions { get; set; }
    }
}
