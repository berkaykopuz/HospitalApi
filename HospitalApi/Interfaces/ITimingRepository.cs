using HospitalApi.Models;

namespace HospitalApi.Interfaces
{
    public interface ITimingRepository
    {
        public bool Add(Timing timing);
        public bool Delete(Timing timing);
        public ICollection<Timing> GetAll();
        public bool Save();
        public bool Update(Timing timing);
        public ICollection<Timing> GetTimingByDoctorId(int doctorId);
    }
}
