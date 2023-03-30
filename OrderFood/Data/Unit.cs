using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderFood.Data
{
    public class Unit
    {
        public Unit()
        {
            Users = new HashSet<User>();
            FoodByRestaurants = new HashSet<FoodByRestaurant>();
            FoodForUsers = new HashSet<FoodForUser>();
            FoodFromRestaurants = new HashSet<FoodForUser>();
            Orders = new HashSet<Order>();
        }

        [Key]
        [StringLength(36)]
        [Column(TypeName = "varchar")]
        public string? UnitID { get; set; }

        [Required]
        [StringLength(255)]
        public string? UnitName { get; set; }

        [Required]
        [StringLength(100)]
        public string? Type { get; set; }

        [Required]
        [StringLength(255)]
        public string? Address { get; set; }

        [Required]
        [StringLength(50)]
        public string? PhoneNumber { get; set; }

        [Required]
        public int? Mode { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<FoodByRestaurant> FoodByRestaurants { get; set; }
        public ICollection<FoodForUser> FoodForUsers { get; set; }
        public ICollection<FoodForUser> FoodFromRestaurants { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
