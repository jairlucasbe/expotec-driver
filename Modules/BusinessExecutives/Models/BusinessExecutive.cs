using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using expotec_driver.Models;

namespace expotec_driver.Modules.BusinessExecutives.Models
{
    public class BusinessExecutive
    {
        [Key]
        [Column(TypeName = "CHAR(36)")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Type { get; set; }

        [StringLength(8)]
        public string? Dni { get; set; }

        public ICollection<Company>? Companies { get; set; }
    }
}
