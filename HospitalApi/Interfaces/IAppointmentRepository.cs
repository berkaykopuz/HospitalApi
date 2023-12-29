using HospitalApi.Models;

namespace HospitalApi.Interfaces
{
    public interface IAppointmentRepository
    {
        bool Add(Appointment appointment);
        bool Save();
        bool Delete(Appointment appointment);
        Task<IEnumerable<Appointment>> GetAll();

        bool IsTaken(Appointment appointment);
        List<Appointment> GetAppointmentsByDoctorId(int id);
        List<Appointment> GetAppointmentsByUserId(string id);
        Appointment GetAppointmentById(int id);
    }
}
