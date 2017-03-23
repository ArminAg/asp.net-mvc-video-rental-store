using System.Collections.Generic;

namespace asp.net_mvc_video_rental_store.Core.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipTypeViewModel> MembershipTypes { get; set; }
        public CustomerViewModel Customer { get; set; }
    }
}