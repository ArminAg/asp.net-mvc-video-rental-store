using System.Collections.Generic;

namespace asp.net_mvc_video_rental_store.Core.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<GenreViewModel> Genres { get; set; }
        public MovieViewModel Movie { get; set; }

        public string Title
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                    return "Edit Movie";

                return "Create Movie";
            }
        }
    }
}