using System.ComponentModel;

namespace OM.WebUI.Models
{
    public class EpostaModel
    {
        public string firma { get; set; }

        [DisplayName("adSoyad")]
        public string adSoyad { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }
        public string mesaj { get; set; }
    }
}