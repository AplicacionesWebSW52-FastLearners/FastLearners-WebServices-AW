using FastLearners.API.Modules.Domain.Models.Modules;
using FastLearners.API.Modules.Domain.Services.Communication;

namespace FastLearners.API.Modules.Domain.Services;

public interface IModuleService
{
    Task<IEnumerable<Module>> ListAsync();
    Task<ModuleResponse> SaveAsync(Module module);
    Task<ModuleResponse> UpdateAsync(int id, Module module);
    Task<ModuleResponse> DeleteAsync(int id);
    Task<Module> FindByIdAsync(int id);

    
}