using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderFood.Data
{
    public class RefreshToken
    {
        public RefreshToken() { }


        [Key]
        [StringLength(36)]
        [Column(TypeName = "varchar")]
        public string? TokenID { get; set; }

        [Required]
        public string? Token { get; set; }

        [Required]
        public string? Jti { get; set; }

        [Required]
        public Boolean? IsUsed { get; set; }

        [Required]
        public Boolean? IsRevoked { get; set; }

        [Required]
        [StringLength(36)]
        public string? UserID { get; set; }

        [Required]
        public DateTime? ExpiredAt { get; set; }

        [Required]
        public DateTime? CreatedAt { get; set; }

        public User? User { get; set; }
    }
}
