using expotec_driver.Modules.BusinessExecutives.Models.Dtos;
using expotec_driver.Modules.BusinessExecutives.Services;
using Microsoft.AspNetCore.Mvc;

namespace expotec_driver.Modules.BusinessExecutives.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessExecutiveController(BusinessExecutiveService businessExecutiveService) : ControllerBase
    {
        private readonly BusinessExecutiveService _businessExecutiveService = businessExecutiveService;

        [HttpGet]
        public async Task<IActionResult> GetAllBusinessExecutives()
        {
            return Ok(await _businessExecutiveService.GetAllBusinessExecutives());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusinessExecutivesDetails(int id)
        {
            return Ok(await _businessExecutiveService.GetOneBusinessExecutive(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBusinessExecutive([FromBody] CreateBusinessExecutiveDto businnessExecutive)
        {
            var created = await _businessExecutiveService.InsertBusinessExecutive(businnessExecutive);
            return Created("created", created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBusinessExecutives([FromBody] UpdateBusinessExecutiveDto businessExecutive, int id)
        {
            var updated = await _businessExecutiveService.UpdateBusinessExecutives(businessExecutive, id);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinessExecutive(int id)
        {
            var deleted = await _businessExecutiveService.DeleteBusinessExecutive(id);
            return Ok(deleted);
        }

    }
}
