using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace asp.net_mvc_video_rental_store.Core.ViewModels
{
    public class MovieFormViewModel
    {
        public string Title
        {
            get
            {
                return (Id != 0) ? "Edit Movie" : "Create Movie";
            }
        }

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }
    }
}