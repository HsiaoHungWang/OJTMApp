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
    //public class ProductMetadata
    //{
    //}
    //public class MemberMetadata
    //{
    //}
}
