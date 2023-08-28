using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.Models
{
    public class VacancyModel
    {
        public int? Id { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public int ExperienceId { get; set; }
        public int EducationId { get; set; }

        [Required(ErrorMessage = "Email boş ola bilməz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon nömrəsi boş ola bilməz")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Vəzifə boş ola bilməz")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Şirkət boş ola bilməz")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Yaş boş ola bilməz")]
        public string Age { get; set; }

        [Required(ErrorMessage = "Maaş boş ola bilməz")]
        public string Salary { get; set; }

        [Required(ErrorMessage = "Tələblər boş ola bilməz")]
        public string Requirements { get; set; }

        [Required(ErrorMessage = "İş haqqında məlumat boş ola bilməz")]
        public string JobInformation { get; set; }

        [Required(ErrorMessage = "Bitmə tarixi boş ola bilməz")]
        public DateTime EndDate { get; set; }
    }
}
