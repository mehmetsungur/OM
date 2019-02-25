using System.ComponentModel.DataAnnotations;

namespace OM.Entity.Complex.Customer.Company
{
    public class CreateCompanyVM
    {
        public string Logo { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
    }
}