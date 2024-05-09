using Microsoft.EntityFrameworkCore;
using Netflix_Server.Models.MovieGroup;
namespace Netflix_Server.Models.MovieGroup.Context
{


    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieImage> MovieImages { get; set; }
        public DbSet<ActorImage> ActorImages { get; set; }
        public DbSet<MovieStatus> MovieStatus { get; set; }
        public DbSet<Actor> MovieActors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Playback> Playbacks { get; set; } = default!;

    }

}
