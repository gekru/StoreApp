using System.Collections.Generic;

namespace Store.BusinessLogic.Models.Base
{
    public class BaseModel
    {
        public long Id { get; set; }
        public ICollection<string> Errors { get; set; }
        public BaseModel()
        {
            Errors = new List<string>();
        }
    }
}
