namespace OJTMApp.Models.ViewModel
{
    public class Top10ProductViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;       

        public decimal? UnitPrice { get; set; }
    }
}
