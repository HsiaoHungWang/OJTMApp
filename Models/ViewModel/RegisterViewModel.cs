using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OJTMApp.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="姓名必填")]
        [Display(Name="姓名")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "電子郵件必填")]
        [EmailAddress(ErrorMessage ="電子郵件格式不正確")]
        [Remote(action: "VerifyEamil", controller: "Member")]
        [Display(Name = "電子郵件")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Range(18,100, ErrorMessage = "年紀要大於18小於100")]

        [Display(Name = "年紀")]
        public int? Age { get; set; }

        [RegularExpression(@"^\d{4,8}$", ErrorMessage = "密碼是4-8個數字")]

        [Display(Name = "密碼")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "密碼不一致")]

        [Display(Name = "密碼確認")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
