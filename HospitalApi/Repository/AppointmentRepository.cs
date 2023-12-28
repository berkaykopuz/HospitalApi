using HospitalApi.Data;
using HospitalApi.Interfaces;
using HospitalApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

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

        public bool IsTaken(Appointment appointment)
        {
            var isTaken = _context.Appointments.Any(a => a.Doctor == appointment.Doctor && a.Date == appointment.Date);

            return isTaken;
        }
        
        public List<Appointment> GetAppointmentsByDoctorId(int id)
        {
            var appointments = _context.Appointments.Where(a => a.Doctor.Id == id).ToList();

            return appointments;
        }

        public List<Appointment> GetAppointmentsByUserId(string id)
        {
            var appointments = _context.Appointments.Where(a => a.Citizen.Id == id).ToList();

            return appointments;
        }
    }
}
