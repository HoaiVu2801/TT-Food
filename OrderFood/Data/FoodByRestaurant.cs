using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderFood.Data
{
    public class FoodByRestaurant
    {
        [Key]
        [StringLength(36)]
        [Column(TypeName = "varchar")]
        public string? FoodID { get; set; }

        [Required]
        [StringLength(255)]
        public string? FoodName { get; set; }


        [Required]
        [StringLength(100)]
        public string? Type { get; set; }

        [Required]
        public DateTime? CreatedDate { get; set; }

        [Required]
        [StringLength(36)]
        [Column(TypeName = "varchar")]
        public string? UnitID { get; set; }

        [Required]
        public int? Mode { get; set; }


        public Unit? Unit { get; set; }
    }
}
