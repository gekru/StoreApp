using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogic.Models.Account
{
    public class ResetPasswordModel
    {
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Token { get; set; }
    }
}
