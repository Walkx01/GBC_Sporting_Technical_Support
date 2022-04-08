using System.ComponentModel.DataAnnotations;

namespace A1.Models
{
	public class Customer
	{
        public int customerID { get; set; }

       

        [Required(ErrorMessage = "Required: First Name"), StringLength(51, MinimumLength = 1)]
        [RegularExpression("^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Last name cannot contain any special characters")]
     
        public string? firstName { get; set; }

        [Required(ErrorMessage = "Required: Last Name"), StringLength(51, MinimumLength = 1)]
        [RegularExpression("^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage ="Last name cannot contain any special characters")]
        public string? lastName { get; set; }

        [Required(ErrorMessage = "Required: Address"), StringLength(51, MinimumLength = 1)]
        public string? address { get; set; }

        [Required(ErrorMessage = "Required: City"), StringLength(51, MinimumLength = 1)]
        public string? city { get; set; }

        [Required(ErrorMessage = "Required: State"), StringLength(51, MinimumLength = 1)]
        public string? state { get; set; }

        [Required(ErrorMessage = "Required: Postal Code"), StringLength(21, MinimumLength = 1)]
        public string? postCode { get; set; }


        [Required(ErrorMessage = "Required: Email"), StringLength(51, MinimumLength = 1)]
        [EmailAddress(ErrorMessage = "Please check the format of you email address")]
        public string? email { get; set; }

        [Phone]
        public string? phone { get; set; }

        [Required(ErrorMessage = "Required: Country")]
        // public string? country { get; set; }
        public int CountryId { get; set; }
        public virtual Country? Country { get; set; }

        public ICollection<Registration> products { get; set; }
    }
}

