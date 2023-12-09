

using System.Text.Json.Serialization;

namespace HospitalApi.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Doctor> ?Doctors { get; set; }
            
        public ICollection<HospitalClinic> ?HospitalClinics { get; set; }
    }
}
