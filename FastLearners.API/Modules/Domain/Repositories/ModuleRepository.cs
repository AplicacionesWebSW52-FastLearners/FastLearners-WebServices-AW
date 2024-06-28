using FastLearners.API.Modules.Domain.Models.Modules;
using FastLearners.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FastLearners.API.Modules.Domain.Repositories;

public class ModuleRepository : IModuleRepository
{
    private readonly AppDbContext _context;
    
    public ModuleRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Module>> ListAsync()
    {
        return await _context.Modules.ToListAsync();
    }
    public async Task AddAsync(Module module)
    {
        await _context.Modules.AddAsync(module);
    }
    public async void Update(Module module)
    {
        _context.Modules.Update(module);
    }
    public async Task<Module> FindByIdAsync(int id)
    {
        return await _context.Modules.FindAsync(id);
    }
    public void Remove(Module module)
    {
        _context.Modules.Remove(module);
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    
    
}