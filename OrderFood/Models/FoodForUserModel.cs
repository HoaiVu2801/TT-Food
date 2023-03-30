namespace OrderFood.Models
{
    public class FoodForUserModel
    {
        public string? FoodID { get; set; }
        public string? FoodName { get; set; }
        public string? Type { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UnitID { get; set; }
        public string? RestaurantID { get; set; }
        public int? Mode { get; set; }
    }
}
