using HospitalApi.Data;
using HospitalApi.Interfaces;
using HospitalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Repository
{
    public class HospitalClinicRepository : IHospitalClinicRepository
    {
        private readonly ApplicationDbContext _context;
        public HospitalClinicRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(HospitalClinic hc)
        {
            _context.Add(hc);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public List<Hospital> GetHospitalsByClinicId(int clinicId)
        {
            // Belirli bir clinic ID'sine sahip hastaneleri getir
            var hospitalClinics = _context.HospitalClinics
                .Where(hc => hc.ClinicId == clinicId)
                .ToList();

            var hospitals = new List<Hospital>();

            foreach (var hc in hospitalClinics)
            {
                Hospital hospital = _context.Hospitals.FirstOrDefault(h => h.Id == hc.HospitalId);
                hospitals.Add(hospital);
            }
            
            return hospitals;
        }
    }
}
