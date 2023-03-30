namespace OrderFood.Models
{
    public class FoodByRestaurantModel
    {
        public string? FoodID { get; set; }

        public string? FoodName { get; set; }

        public string? Type { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? UnitID { get; set; }
        public UnitModel? Unit { get; set; }

        public int? Mode { get; set; }
    }
}
