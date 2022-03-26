using System.ComponentModel.DataAnnotations;

namespace A1.Models
{
	public class Technician
	{
        public int TechnicianID { get; set; }

        [Required(ErrorMessage = "Required: name")]
        public string? name { get; set; }

        [Required(ErrorMessage = "Required: Email")]
        [EmailAddress]
        public string? email { get; set; }

        [Required(ErrorMessage = "Required: Phone")]
        [Phone]
        public string? phone { get; set; }
    }
}

