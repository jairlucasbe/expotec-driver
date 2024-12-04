using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace expotec_driver.Models
{
    public class Confirmation
    {
        public int Id { get; set; }
        public required DateTime ConfirmationDate { get; set; }
        public required string ConfirmationResponse { get; set; }
        public required int BusinessExecutiveId { get; set; }
        public required int ParticipantId { get; set; }
    }
}
