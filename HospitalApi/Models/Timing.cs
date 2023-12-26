using System.ComponentModel.DataAnnotations;

namespace HospitalApi.Models
{
    public class Timing
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime WorkDay { get; set; }
        public int shiftStart { get; set; }
        public int shiftEnd { get; set; }
        public Doctor Doctor { get; set; }
    }
}
