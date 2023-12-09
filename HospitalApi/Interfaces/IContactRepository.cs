using HospitalApi.Models;

namespace HospitalApi.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAll();
        bool Add(Contact contact);

        bool Save();

    }
}
