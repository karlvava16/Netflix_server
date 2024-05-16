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
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
    public class RegisterModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PricingPlanId { get; set; }
    }

}
