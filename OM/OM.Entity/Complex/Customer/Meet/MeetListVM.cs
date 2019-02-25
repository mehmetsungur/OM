using System;

namespace OM.Entity.Complex.Customer.Meet
{
    public class MeetListVM
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }

        public string CompanyName { get; set; }
        public string Contact { get; set; }
        public string Caption { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
    }
}