namespace OrderFood.Models
{
    public class OrderDetailModel
    {
        public string? OrderDetailID { get; set; }
        public string? OrderID { get; set; }
        public string? FoodID { get; set; }
        public int? Quantity { get; set; }
        public int? Mode { get; set; }
    }
}
