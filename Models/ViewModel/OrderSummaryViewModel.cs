using System.ComponentModel.DataAnnotations;

namespace OJTMApp.Models.ViewModel
{
    public class OrderSummaryViewModel
    {
        [Display(Name = "訂單編號")]
        public int OrderId { get; set; }

        [Display(Name = "訂單日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "訂單數量")]
        public int OrderQty { get; set; }

        [Display(Name = "訂單金額")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        public decimal OrderAmount { get; set; }
    }
}
