using Netflix_Server.Models.MovieGroup;

namespace Netflix_Server.View_Model
{
    public class FilteredMovie
    {
        public FilteredMovie(List<Movie>m,int max) {
            filteredMovies = m;
            maxFilteredFilms=max;
        
        }
        public List<Movie> filteredMovies {  get; set; }

        public int maxFilteredFilms {  get; set; }

    }
}
