using HospitalApi.Data;
using HospitalApi.Interfaces;
using HospitalApi.Models;

namespace HospitalApi.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;
        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Contact contact)
        {
            _context.Add(contact);
            return Save();
        }

        public Task<IEnumerable<Contact>> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
