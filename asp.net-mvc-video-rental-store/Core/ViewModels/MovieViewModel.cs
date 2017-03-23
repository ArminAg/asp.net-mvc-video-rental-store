using System;
using System.ComponentModel.DataAnnotations;

namespace asp.net_mvc_video_rental_store.Core.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        public GenreViewModel Genre { get; set; }
    }
}