using HospitalApi.Data;
using HospitalApi.Interfaces;
using HospitalApi.Models;

namespace HospitalApi.Repository
{
    public class CitizenRepository : ICitizenRepository
    {

        private readonly ApplicationDbContext _context;

        public CitizenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Citizen GetCitizenByName(string name)
        {
            Citizen citizen = _context.Users.FirstOrDefault(c => c.UserName == name);

            return citizen;
        }
    }
}
