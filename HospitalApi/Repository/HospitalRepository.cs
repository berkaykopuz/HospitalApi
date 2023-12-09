using HospitalApi.Data;
using HospitalApi.Interfaces;
using HospitalApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HospitalApi.Repository
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly ApplicationDbContext _context;
        public HospitalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Hospital hospital)
        {
            _context.Add(hospital);
            return Save();
        }

        public bool Delete(Hospital hospital)
        {
            _context.Remove(hospital);
            return Save();
        }

        public ICollection<Hospital> GetAll()
        {
            return _context.Hospitals.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Hospital hospital)
        {
            _context.Update(hospital);
            return Save();
        }

        public Hospital GetHospitalById(int hospitalId)
        {
            return _context.Hospitals.FirstOrDefault(h => h.Id == hospitalId);
        }

        public bool HospitalExists(int hospitalId)
        {
            return _context.Hospitals.Any(h => h.Id == hospitalId);
        }
    }
}
