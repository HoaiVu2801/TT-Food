using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderFood.Data
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [StringLength(36)]
        [Column(TypeName = "varchar")]
        public string? OrderID { get; set; }

        [Required]
        [StringLength(36)]
        [Column(TypeName = "varchar")]
        public string? UserID { get; set; }

        [Required]
        public DateTime? OrderDate { get; set; }

        [Required]
        public int? Price { get; set; }

        [Required]
        [StringLength(36)]
        [Column(TypeName = "varchar")]
        public string? UnitID { get; set; }


        [Required]
        [StringLength(100)]
        public string? Status { get; set; }

        [Required]
        public int? Mode { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public User? User { get; set; }
        public Unit? Unit { get; set; }
    }
}
