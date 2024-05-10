using Netflix_Server.Models.MovieGroup;

namespace Netflix_Server.View_Model
{
    public class Filter
    {

        public int Elements {  get; set; }

        public int CurrentPage { get; set; }

        public string? InputFilter {  get; set; }

        public int[]? GenresIdFilter { get; set; }



    }
}
