using HospitalApi.Models;

namespace HospitalApi.Interfaces
{
    public interface ICitizenRepository
    {
        Citizen GetCitizenByName(string name);
    }
}
