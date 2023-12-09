using HospitalApi.Models;

namespace HospitalApi.Interfaces
{
    public interface IAppointmentRepository
    {
        bool Add(Appointment appointment);
        bool Save();
        Task<IEnumerable<Appointment>> GetAll();
    }
}
