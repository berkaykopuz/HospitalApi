using HospitalApi.Data;
using HospitalApi.Interfaces;
using HospitalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;
        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Doctor doctor)
        {
            _context.Add(doctor);
            return Save();
        }

        public bool Delete(Doctor doctor)
        {
            _context.Remove(doctor);
            return Save();
        }

        public ICollection<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Doctor doctor)
        {
            _context.Update(doctor);
            return Save();
        }

        public Doctor GetDoctorById(int doctorId)
        {
            return _context.Doctors.Find(doctorId);
        }

        public ICollection<Doctor> GetDoctorsByHospitalId(int hospitalId)
        {
            var doctors = _context.Doctors.Where(d => d.Hospital.Id == hospitalId).ToList();

            return doctors;
        }

        public bool DoctorExists(int doctorId)
        {
            return _context.Doctors.Any(h => h.Id == doctorId);
        }
    }
}
