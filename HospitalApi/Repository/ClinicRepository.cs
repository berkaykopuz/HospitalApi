using HospitalApi.Data;
using HospitalApi.Interfaces;
using HospitalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Repository
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly ApplicationDbContext _context;
        public ClinicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Clinic clinic)
        {
            _context.Add(clinic);
            return Save();
        }

        public bool Delete(Clinic clinic)
        {
            _context.Remove(clinic);
            return Save();
        }

        public ICollection<Clinic> GetAll()
        {
            return _context.Clinics.ToList();
        }

        public async Task<Clinic> GetByIdAsync(int id)
        {
            return await _context.Clinics.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Clinic clinic)
        {
            _context.Update(clinic);
            return Save();
        }

        public Clinic GetClinicById(int clinicId)
        {
            return _context.Clinics.FirstOrDefault(c => c.Id == clinicId);
        }

        public bool ClinicExists(int clinicId)
        {
            return _context.Clinics.Any(c => c.Id == clinicId);
        }

    }
}
