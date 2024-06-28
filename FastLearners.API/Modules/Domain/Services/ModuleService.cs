using FastLearners.API.Modules.Domain.Models.Modules;
using FastLearners.API.Modules.Domain.Repositories;
using FastLearners.API.Modules.Domain.Services.Communication;
using FastLearners.API.Shared.Domain.Repositories;

namespace FastLearners.API.Modules.Domain.Services;

public class ModuleService : IModuleService
{
    private readonly IModuleRepository _moduleRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public ModuleService(IModuleRepository moduleRepository, IUnitOfWork unitOfWork)
    {
        _moduleRepository = moduleRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Module>> ListAsync()
    {
        return await _moduleRepository.ListAsync();
    }
    public async Task<ModuleResponse> SaveAsync(Module module)
    {
        try
        {
            module.CreatedAt = DateTime.UtcNow;
            module.UpdatedAt = DateTime.UtcNow;
            
            await _moduleRepository.AddAsync(module);
            await _unitOfWork.CompleteAsync();
            
            return new ModuleResponse(module);
        }
        catch (Exception ex)
        {
            return new ModuleResponse($"An error occurred when saving the module: {ex.Message}");
        }
    }
    public async Task<ModuleResponse> UpdateAsync(int id, Module module)
    {
        var existingModule = await _moduleRepository.FindByIdAsync(id);
        
        if (existingModule == null)
        {
            return new ModuleResponse("Module not found.");
        }
        
        existingModule.Name = module.Name;
        existingModule.Description = module.Description;
        existingModule.Content = module.Content;
        
        try
        {
            _moduleRepository.Update(existingModule);
            await _unitOfWork.CompleteAsync();
            
            return new ModuleResponse(existingModule);
        }
        catch (Exception ex)
        {
            return new ModuleResponse($"An error occurred when updating the module: {ex.Message}");
        }
    }
    public async Task<ModuleResponse> DeleteAsync(int id)
    {
        var existingModule = await _moduleRepository.FindByIdAsync(id);
        
        if (existingModule == null)
        {
            return new ModuleResponse("Module not found.");
        }
        
        try
        {
            _moduleRepository.Remove(existingModule);
            await _unitOfWork.CompleteAsync();
            
            return new ModuleResponse(existingModule);
        }
        catch (Exception ex)
        {
            return new ModuleResponse($"An error occurred when deleting the module: {ex.Message}");
        }
    }

    public async Task<Module> FindByIdAsync(int id)
    {
        return await _moduleRepository.FindByIdAsync(id);
    }

}