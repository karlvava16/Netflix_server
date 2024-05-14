using Microsoft.EntityFrameworkCore;
using Netflix_Server.Models.MovieGroup;
using Netflix_Server.Models.UserGroup;
namespace Netflix_Server.Models.Context
{


    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
<<<<<<< Updated upstream
=======
            if (Database.EnsureCreated())
            {
                var actionGenre = new Genre { Name = "Action" };
                var dramaGenre = new Genre { Name = "Drama" };
                Genres.AddRange(actionGenre, dramaGenre);
                SaveChanges();

                // Добавляем актеров
                var christianBale = new Actor { Name = "Christian Bale" };
                var heathLedger = new Actor { Name = "Heath Ledger" };
                var tomHanks = new Actor { Name = "Tom Hanks" };
                var robinWright = new Actor { Name = "Robin Wright" };
               Actors.AddRange(christianBale, heathLedger, tomHanks, robinWright);
                SaveChanges(); // Сначала сохраняем изменения в актерах

                // Теперь добавляем изображения актеров
                var actorImage1 = new ActorImage { PosterPath = "path/to/actor1.jpg", Alt = "Christian Bale", ActorId = christianBale.Id };
                var actorImage2 = new ActorImage { PosterPath = "path/to/actor2.jpg", Alt = "Heath Ledger", ActorId = heathLedger.Id };
                var actorImage3 = new ActorImage { PosterPath = "path/to/actor3.jpg", Alt = "Tom Hanks", ActorId = tomHanks.Id };
                var actorImage4 = new ActorImage { PosterPath = "path/to/actor4.jpg", Alt = "Robin Wright", ActorId = robinWright.Id };
                ActorImages.AddRange(actorImage1, actorImage2, actorImage3, actorImage4);
                SaveChanges(); // Сохраняем изменения в изображениях актеров
                               // Добавляем фильмы
                var movie1 = new Movie
                {
                    Title = "The Dark Knight",
                    Director = "Christopher Nolan",
                    IsNetflix = true,
                    IsTop10 = true,
                    Description = "Description of The Dark Knight...",
                    Status = new MovieStatus { Views = 100 },

                };

                var movie2 = new Movie
                {
                    Title = "Forrest Gump",
                    Director = "Robert Zemeckis",
                    IsNetflix = false,
                    IsTop10 = true,
                    Description = "Description of Forrest Gump...",
                    Status = new MovieStatus { Views = 200 },
                };

             Movies.AddRange(movie1, movie2);
              SaveChanges(); // Сначала сохраняем изменения в фильмах

                // Теперь добавляем изображения фильмов
                var movieImage1 = new MovieImage { PosterPath = "path/to/movie1.jpg", Alt = "The Dark Knight Poster", MovieId = movie1.Id };
                var movieImage2 = new MovieImage { PosterPath = "path/to/movie2.jpg", Alt = "Forrest Gump Poster", MovieId = movie2.Id };
               MovieImages.AddRange(movieImage1, movieImage2);
             SaveChanges(); // Сохраняем изменения в изображениях фильмов
                // Добавляем записи о воспроизведении
                var playback1 = new Playback { QualityLevel = 1080, Path = "path/to/movie1.mp4", Movie = movie1 };
                var playback2 = new Playback { QualityLevel = 720, Path = "path/to/movie2.mp4", Movie = movie2 };
               Playbacks.AddRange(playback1, playback2);

                // Сохраняем изменения в базе данных
                 SaveChanges();
            }
>>>>>>> Stashed changes
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieImage> MovieImages { get; set; }
        public DbSet<ActorImage> ActorImages { get; set; }
        public DbSet<MovieStatus> MovieStatus { get; set; }
        public DbSet<Actor> MovieActors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Playback> Playbacks { get; set; } = default!;


        public DbSet<Feature> Features { get; set; } 
        public DbSet<PricingPlan> PricingPlans { get; set; }
        public DbSet<User> Users { get; set; }

    }

}
