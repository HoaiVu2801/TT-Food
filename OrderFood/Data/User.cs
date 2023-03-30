using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace OrderFood.Data
{
    public class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [StringLength(36)]
        [Column(TypeName = "varchar")]
        public string? UserID { get; set; }

        [Required]
        [StringLength(100)]

        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }


        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(50)]
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(36)]
        [Column(TypeName = "varchar")]
        public string? RoleID { get; set; }

        [Required]
        [StringLength(36)]
        [Column(TypeName = "varchar")]
        public string? UnitID { get; set; }

        [Required]
        public int? Mode { get; set; }


        public ICollection<Order> Orders { get; set; }
        public Unit? Unit { get; set; }

        public Role? Role { get; set; }
    }
}
