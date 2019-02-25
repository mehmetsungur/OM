using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OM.Entity.Complex.Customer.Company
{
    public class UpdateCompanyVM
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Alan boş bırakılamaz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Alan boş bırakılamaz.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Alan boş bırakılamaz.")]
        public string District { get; set; }

        [Required(ErrorMessage = "Alan boş bırakılamaz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Alan boş bırakılamaz.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Alan boş bırakılamaz.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Alan boş bırakılamaz.")]
        public string Description { get; set; }
    }
}