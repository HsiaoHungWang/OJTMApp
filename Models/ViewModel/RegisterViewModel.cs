using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OJTMApp.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="姓名必填")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "電子郵件必填")]
        [EmailAddress(ErrorMessage ="電子郵件格式不正確")]
        [Remote(action: "VerifyEamil", controller: "Member")]
        public string? Email { get; set; }

        [Range(18,100, ErrorMessage = "年紀要大於18小於100")]
        public int? Age { get; set; }

        [RegularExpression(@"^\d{4,8}$", ErrorMessage = "密碼是4-8個數字")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "密碼不一致")]
        public string? ConfirmPassword { get; set; }
    }
}
