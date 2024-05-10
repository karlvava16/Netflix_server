using Netflix_Server.Models.MovieGroup;

namespace Netflix_Server.Models.UserGroup
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; } 
        public string HashedPassword { get; set; } 
        public string PasswordSalt { get; set; } 
        public DateTime? RegistrationDate { get; set; } 
        public PricingPlan? PricingPlan { get; set; }
        public int PricingPlanId { get; set; }
        public ICollection<Movie>? WatchedMovies { get; set; }
    }
}
