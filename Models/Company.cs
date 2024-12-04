using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace expotec_driver.Models
{
    public class Company
    {
        public int? Id { get; set; }
        public required string Name { get; set; }
        public required string Ruc { get; set; }
        public string? Address { get; set; }
        public string? District { get; set; }
        public string? Region { get; set; }
        public int? BusinessExecutiveId { get; set; }
    }
}
