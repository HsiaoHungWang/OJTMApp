using System.ComponentModel.DataAnnotations;

namespace OJTMApp.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="姓名必填")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "電子郵件必填")]
        public string? Email { get; set; }

        public int? Age { get; set; }

        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
