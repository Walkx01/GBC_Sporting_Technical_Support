using System.ComponentModel.DataAnnotations;

namespace A1.Models
{
	public class Incident
	{
        public int IncidentID { get; set; }

        [Required(ErrorMessage = "Required: Customer")]
        public int customerID { get; set; }

        [Required(ErrorMessage = "Required: Product")]
        public int productID { get; set; }

        public int? technicianID { get; set; }

        [Required(ErrorMessage = "Required: Title")]
        public string? title { get; set; }

        [Required(ErrorMessage = "Required: Description")]
        public string? description { get; set; }

        [Required(ErrorMessage = "Required: Date Closed")]
        [DataType(DataType.DateTime)]
        public DateTime? dateClosed { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? dateOpened { get; set; }
        public Customer? customer { get; set; }

        public Product? product { get; set; }

        public Technician? technician { get; set; }

    }
}

