namespace OrderFood.Models
{
    public class OrderModel
    {
        public string? OrderID { get; set; }
        public string? UserID { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? Price { get; set; }
        public string? UnitID { get; set; }
        public string? Status { get; set; }
        public int? Mode { get; set; }
    }
}
