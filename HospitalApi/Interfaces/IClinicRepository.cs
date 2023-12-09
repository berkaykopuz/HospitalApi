using HospitalApi.Models;

namespace HospitalApi.Interfaces
{
    public interface IClinicRepository
    {
        bool Add(Clinic clinic);
        bool Update(Clinic clinic);
        bool Delete(Clinic clinic);
        bool Save();
        ICollection<Clinic> GetAll();
        Clinic GetClinicById(int clinicId);
        bool ClinicExists(int clinicId);
    }
}
