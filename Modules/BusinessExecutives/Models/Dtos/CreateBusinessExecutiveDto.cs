namespace expotec_driver.Modules.BusinessExecutives.Models.Dtos
{
    public class CreateBusinessExecutiveDto
    {
        public required string Name { get; set; } = string.Empty;
        public string? Type { get; set; }
        public string? Dni { get; set; }
    }
}
