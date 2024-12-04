using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace expotec_driver.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Position { get; set; }
        public string? Area { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Type { get; set; }
        public string? Comments { get; set; }
        public bool? Attended { get; set; }
        public bool? IsCandidateForCocktail { get; set; }
        public int NumberConfirmations { get; set; }
        public bool IsActiveConfirmation { get; set; }
        public int? CompanyId { get; set; }
    }
}
