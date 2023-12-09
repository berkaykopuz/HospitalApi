using HospitalApi.Data;
using HospitalApi.Interfaces;
using HospitalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context) {
            _context = context;
        }
        public bool Add(Appointment appointment)
        {
            _context.Add(appointment);
            return Save();
        }

        public Task<IEnumerable<Appointment>> GetAll()
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
