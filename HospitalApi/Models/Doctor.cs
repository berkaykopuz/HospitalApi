

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HospitalApi.Models
{
    public class Doctor
    {
        
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public Hospital Hospital { get; set; }
        public ICollection<Timing>? Timings { get; set; }

        public ICollection<Appointment> ?Appointments { get; set; }

    }
}
