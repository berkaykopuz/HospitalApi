using HospitalApi.Models;
using System.ComponentModel.DataAnnotations;

namespace HospitalApi.Dto
{
    public class TimingDto
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime WorkDay { get; set; }
        public int shiftStart { get; set; }
        public int shiftEnd { get; set; }
    }
}
