using Microsoft.EntityFrameworkCore;
namespace Netflix_Server.Models
{
    

    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> MovieGenres { get; set; }
        public DbSet<MovieImage> MovieImages { get; set; }
        public DbSet<Actor> MovieActors { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }

}
