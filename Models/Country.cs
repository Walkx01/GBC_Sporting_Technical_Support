using System.ComponentModel.DataAnnotations;

namespace A1.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string? Name { get; set; }

        public ICollection<Customer>? Customers { get; set; }

    }
}
