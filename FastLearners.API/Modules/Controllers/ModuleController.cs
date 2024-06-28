using FastLearners.API.Modules.Domain.Models.Modules;
using FastLearners.API.Modules.Domain.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FastLearners.API.Modules.Controllers
{
    [Route("/api/modules")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;

        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService ?? throw new ArgumentNullException(nameof(moduleService));
        }

        [HttpGet]
        public async Task<IEnumerable<Module>> GetAllAsync()
        {
            var modules = await _moduleService.ListAsync();
            return modules;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var module = await _moduleService.FindByIdAsync(id);
            if (module == null)
                return NotFound();

            return Ok(module);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Module module)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = await _moduleService.SaveAsync(module);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Module);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Module module)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _moduleService.UpdateAsync(id, module);

            if (!result.Success)
                return BadRequest(new { message = result.Message });

            return Ok(result.Module);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _moduleService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(new { message = result.Message });

            return Ok(result.Module);
        }
    }
}
