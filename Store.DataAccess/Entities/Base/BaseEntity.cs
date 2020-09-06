using System;

namespace Store.DataAccess.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsRemoved { get; set; }

        public BaseEntity()
        {
            // Initializing current time
            CreationDate = DateTime.Now;
        }
    }
}
