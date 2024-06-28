using FastLearners.API.Organizations.Domain.Models;
using FastLearners.API.Organizations.Domain.Services;
using Microsoft.AspNetCore.Mvc;


namespace FastLearners.API.Organizations.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<IEnumerable<Organization>> GetAllAsync()
        {
            var organizations = await _organizationService.ListAsync();
            return organizations;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var organization = await _organizationService.FindByIdAsync(id);
            if (organization == null)
                return NotFound();
            
            return Ok(organization);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Organization organization)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = await _organizationService.SaveAsync(organization);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Organization);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Organization organization)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _organizationService.UpdateAsync(id, organization);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Organization);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _organizationService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Organization);
        }
    }
}