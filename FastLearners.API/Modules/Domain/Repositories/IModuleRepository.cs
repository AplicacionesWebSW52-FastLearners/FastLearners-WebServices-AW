using FastLearners.API.Modules.Domain.Models.Modules;

namespace FastLearners.API.Modules.Domain.Repositories;

public interface IModuleRepository
{
    Task<IEnumerable<Module>> ListAsync();
    Task AddAsync(Module module);
    void Update(Module module);
    Task<Module> FindByIdAsync(int id);
    void Remove(Module module);
   
    
}