namespace A1.Models
{
    public class IncidentViewModel
    {
        public Incident incident { get; set; }
        public Customer customer { get; set; }
        public Product product { get; set; }
        public Technician technician { get; set; }

        public string operation { get; set; }

    }
}
