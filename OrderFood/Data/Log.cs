using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderFood.Data
{
    public class Log
    {
        [Key]
        [StringLength(36)]
        [Column(TypeName = "varchar")]
        public string? LogID { get; set; }

        [Required]
        [StringLength(100)]
        public string? Action { get; set; }

        [Required]
        [StringLength(36)]
        [Column(TypeName = "varchar")]
        public string? UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string? Table { get; set; }

        [Required]
        public DateTime? Time { get; set; }

        [Required]
        [StringLength(255)]
        public string? Status { get; set; }

        public string? Content { get; set; }
    }
}
