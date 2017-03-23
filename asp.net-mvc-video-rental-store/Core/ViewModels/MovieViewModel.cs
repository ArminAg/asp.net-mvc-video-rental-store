using System;

namespace asp.net_mvc_video_rental_store.Core.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public byte NumberInStock { get; set; }

        public GenreViewModel Genre { get; set; }
    }
}