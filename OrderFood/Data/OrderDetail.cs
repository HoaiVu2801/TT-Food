using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderFood.Data
{
    public class OrderDetail
    {
        [Key]
        [StringLength(36)]
        [Column(TypeName = "varchar")]
        public string? OrderDetailID { get; set; }

        [Required]
        [StringLength(36)]
        [Column(TypeName = "varchar")]
        public string? OrderID { get; set; }

        [Required]
        [StringLength(36)]
        [Column(TypeName = "varchar")]

        public string? FoodID { get; set; }

        [Required]
        [Range(0, 10)]
        public int? Quantity { get; set; }

        [Required]
        public int? Mode { get; set; }

        public Order? Order { get; set; }

        public FoodForUser? FoodForUser { get; set; }
    }
}
