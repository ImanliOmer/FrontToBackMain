using System.ComponentModel.DataAnnotations;

namespace FrontToBack.ViewModels
{
    public class RegisterVM
    {
        [Required,StringLength(100)]
        public string FullName { get; set; }
        [Required, StringLength(100)]

        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RepaetPassword { get; set; }
    }
}
