using System.ComponentModel.DataAnnotations;

namespace Netflix_Server.Models.UserGroup
{
    public class EmailRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PricingPlanId { get; set; }
    }

}
