using System.ComponentModel.DataAnnotations;

namespace A1.Models
{
	public class Product
	{
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Required: Code")]
        public string? code { get; set; }

        [Required(ErrorMessage = "Required: Name")]
        [RegularExpression("^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Name cannot contain any special characters")]
        public string? name { get; set; }

        [Required(ErrorMessage = "Required: Yearly Price")]
        public double? yearlyPrice { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime releaseDate { get; set; } = DateTime.Now;

        public ICollection<Registration> customers { get; set; }

    }
}

