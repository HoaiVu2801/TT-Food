using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderFood.Data
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        [Key]
        [StringLength(36)]
        [Column(TypeName = "varchar")]
        public string? RoleID { get; set; }

        [Required]
        [StringLength(255)]
        public string? RoleName { get; set; }

        [Required]
        [Range(0, 255)]

        //thứ tự
        public int? Order { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [Required]
        public int? Mode { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
