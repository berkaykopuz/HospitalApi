using HospitalApi.Models;

namespace HospitalApi.Interfaces
{
    public interface ICitizenRepository
    {
        Citizen GetCitizenById(string id);
    }
}
