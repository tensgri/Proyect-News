using System.ComponentModel.DataAnnotations;

namespace newAdmin.Models
{
    public class loginViewModel
    {
        [Required]
        [Display(Name ="Username")]
        public string  userName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string password{ get; set; }
    }
}
