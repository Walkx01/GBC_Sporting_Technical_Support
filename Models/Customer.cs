using System.ComponentModel.DataAnnotations;

namespace A1.Models
{
	public class Customer
	{
        public int customerID { get; set; }

        [Required(ErrorMessage = "Required: First Name")]
        [RegularExpression("^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Last name cannot contain any special characters")]
        public string? firstName { get; set; }

        [Required(ErrorMessage = "Required: Last Name")]
        [RegularExpression("^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage ="Last name cannot contain any special characters")]
        public string? lastName { get; set; }

        [Required(ErrorMessage = "Required: Address")]
        public string? address { get; set; }

        [Required(ErrorMessage = "Required: City")]
        public string? city { get; set; }

        [Required(ErrorMessage = "Required: State")]
        public string? state { get; set; }

        [Required(ErrorMessage = "Required: Postal Code")]
        public string? postCode { get; set; }

        [Required(ErrorMessage = "Required: Country")]
        public string? country { get; set; }

        [EmailAddress(ErrorMessage = "Please check the format of you email address")]
        public string? email { get; set; }

        [Phone]
        public string? phone { get; set; }
    }
}

