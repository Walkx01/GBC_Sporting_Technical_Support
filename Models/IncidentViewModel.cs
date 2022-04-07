namespace A1.Models
{
    public class IncidentViewModel
    {
        public Incident Incident { get; set; }
        public List<Product> Products { get; set; }
        public List<Technician> Technicians { get; set; }
        public List<Customer> Customer { get; set; }
        public string filter { get; set; } = "all";
        public string page { get; set; }
    }
}
