using System.ComponentModel.DataAnnotations;

namespace HospitalApi.Models
{
    public class Contact
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon alanı zorunludur.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Konu alanı zorunludur.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mesaj alanı zorunludur.")]
        public string Message { get; set; }
    }
}
