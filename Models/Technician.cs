using System.ComponentModel.DataAnnotations;

namespace A1.Models
{
	public class Technician
	{
        public int TechnicianID { get; set; }

        [Required(ErrorMessage = "Required: name")]
        [RegularExpression("^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Name cannot contain any special characters")]
        public string? name { get; set; }

        [Required(ErrorMessage = "Required: Email")]
        [EmailAddress]
        public string? email { get; set; }

        [Required(ErrorMessage = "Required: Phone")]
        [Phone]
        public string? phone { get; set; }
    }
}

