namespace OJTMApp.Models.ViewModel
{
    public class ProductOrdersViewModel
    {
        public  string? ProductName { get; set; }
        public string? SupplierName { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
