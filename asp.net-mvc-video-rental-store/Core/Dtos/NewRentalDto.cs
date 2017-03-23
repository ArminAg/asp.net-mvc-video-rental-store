using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace asp.net_mvc_video_rental_store.Core.Dtos
{
    public class NewRentalDto
    {
        [Required]
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}