using System.ComponentModel.DataAnnotations;

namespace HospitalApi.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public Doctor Doctor { get; set; }

        public Citizen Citizen { get; set; }
    }
}
