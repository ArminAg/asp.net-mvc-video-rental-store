using System;

namespace asp.net_mvc_video_rental_store.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte NumberInStock { get; set; }

        // Navigation Properties
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}