using HospitalApi.Models;

namespace HospitalApi.Interfaces
{
    public interface IHospitalRepository
    {
        bool Add(Hospital hospital);
        bool Update(Hospital hospital);
        bool Delete(Hospital hospital);
        bool Save();
        ICollection<Hospital> GetAll();
        Hospital GetHospitalById(int hospitalId);
        bool HospitalExists(int hospitalId);
    }
}
