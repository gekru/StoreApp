using System;

namespace Store.DataAccess.Entities.Base
{
    public interface IBaseEntity
    {
        DateTime CreationDate { get; set; }
        long Id { get; set; }
        bool IsRemoved { get; set; }
    }
}