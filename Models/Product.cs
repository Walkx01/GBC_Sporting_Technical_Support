using System.ComponentModel.DataAnnotations;

namespace A1.Models
{
	public class Product
	{
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Required: Code")]
        public string? code { get; set; }

        [Required(ErrorMessage = "Required: Name")]
        public string? name { get; set; }

        [Required(ErrorMessage = "Required: Yearly Price")]
        public double? yearlyPrice { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime releaseDate { get; set; } = DateTime.Now;

    }
}

