using HospitalApi.Models;

namespace HospitalApi.Interfaces
{
    public interface IDoctorRepository
    {
        ICollection<Doctor> GetAll();
        bool Add(Doctor doctor);
        bool Update(Doctor doctor);
        bool Delete(Doctor doctor);
        bool Save();
        Doctor GetDoctorById(int doctorId);
        ICollection<Doctor> GetDoctorsByHospitalId(int id);
        bool DoctorExists(int doctorId);
    }
}
