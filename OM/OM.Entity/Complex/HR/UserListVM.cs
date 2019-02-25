using System;

namespace OM.Entity.Complex.HR
{
    public class UserListVM
    {
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public string RoleName { get; set; }
        public int PersonnelCode { get; set; }
    }
}