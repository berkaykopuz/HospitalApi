using System.ComponentModel.DataAnnotations;

namespace HospitalApi.Dto
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public string CitizenId { get; set; }
    }
}
