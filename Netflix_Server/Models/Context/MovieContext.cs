using Microsoft.EntityFrameworkCore;
using Netflix_Server.Models.UserGroup;
namespace Netflix_Server.Models.Context
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
            if (Database.EnsureCreated())
            {

            }
        }
        
        

        public DbSet<Feature> Features { get; set; } 
        public DbSet<PricingPlan> PricingPlans { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
