using HospitalApi.Models;

namespace HospitalApi.Interfaces
{
    public interface IHospitalClinicRepository
    {
        public bool Add(HospitalClinic hc);
        public bool Save();

        public List<Hospital> GetHospitalsByClinicId(int clinicId);
    }
}
