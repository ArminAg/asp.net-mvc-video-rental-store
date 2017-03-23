using asp.net_mvc_video_rental_store.Core.Models;
using asp.net_mvc_video_rental_store.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace asp.net_mvc_video_rental_store.Persistence.Repositories
{
    public class MembershipTypeRepository : IMembershipTypeRepository
    {
        private ApplicationDbContext _context;

        public MembershipTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MembershipType> GetAllMembershipTypes()
        {
            return _context.MembershipTypes.ToList();
        }
    }
}