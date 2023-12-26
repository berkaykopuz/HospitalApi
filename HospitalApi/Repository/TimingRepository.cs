using HospitalApi.Data;
using HospitalApi.Interfaces;
using HospitalApi.Models;

namespace HospitalApi.Repository
{
    public class TimingRepository : ITimingRepository
    {
        private readonly ApplicationDbContext _context;
        public TimingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Timing timing)
        {
            _context.Add(timing);
            return Save();
        }

        public bool Delete(Timing timing)
        {
            _context.Remove(timing);
            return Save();
        }

        public ICollection<Timing> GetAll()
        {
            return _context.Timings.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Timing timing)
        {
            _context.Update(timing);
            return Save();
        }

        public ICollection<Timing> GetTimingByDoctorId(int doctorId)
        {
            var timings = _context.Timings.Where(t => t.Doctor.Id == doctorId).ToList();

            return timings;
        }

    }
}
