namespace OJTMApp.Models.ViewModel
{
    public class CustomerOrdersViewModel
    {
        public required string CustomerId { get; set; }
        public string? CompanyName { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
