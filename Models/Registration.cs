using System.ComponentModel.DataAnnotations;

namespace A1.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationId { get; set; }

        public int? customerId { get; set; }
        public Customer? customer { get; set; }
        public int? productId { get; set; }
        public Product? product { get; set; }
    }
}
