using System.ComponentModel.DataAnnotations;

namespace OJTMApp.Models.Metadata
{
    public class ShipperMetadata
    {
        [Display(Name = "公司名稱")]
        [Required(ErrorMessage = "公司名稱必填")]
        public string CompanyName { get; set; } = null!;

        [Display(Name = "電話")]
        public string? Phone { get; set; }
    }
    public class ProductMetadata
    {
        [Display(Name = "產品名稱")]
        public string ProductName { get; set; } = null!;
    }
    //public class MemberMetadata
    //{
    //}
}
