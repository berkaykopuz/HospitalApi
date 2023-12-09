using Microsoft.AspNetCore.Identity;

namespace HospitalApi.Models
{
    public class Citizen : IdentityUser
    {
        public ICollection<Appointment> ?Appointments { get; set; }
    }
}
