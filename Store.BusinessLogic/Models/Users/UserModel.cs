using Store.BusinessLogic.Models.Base;
using System.Collections.Generic;

namespace Store.BusinessLogic.Models.Users
{
    public class UserModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }

    }
}
