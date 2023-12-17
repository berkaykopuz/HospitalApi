using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalApi.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [Column(TypeName = "timestamp with time zone")]
        public DateTime Date { get; set; }
        public Doctor Doctor { get; set; }
        public Citizen Citizen { get; set; }
    }
}
