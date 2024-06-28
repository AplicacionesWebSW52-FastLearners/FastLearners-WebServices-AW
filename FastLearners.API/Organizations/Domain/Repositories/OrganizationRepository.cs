using FastLearners.API.Organizations.Domain.Models;
using FastLearners.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using FastLearners.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace FastLearners.API.Organizations.Domain.Repositories;

public class OrganizationRepository :  IOrganizationRepository
{
    private readonly AppDbContext _context;
    
    public OrganizationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Organization>> ListAsync()
    {
        
        return await _context.Organizations.ToListAsync();
    }

    public async Task AddAsync(Organization organization)
    {
       
        await _context.Organizations.AddAsync(organization);
    }

    public void Update(Organization organization)
    {
        _context.Organizations.Update(organization);
    }

    public void Remove(Organization organization)
    {
        _context.Organizations.Remove(organization);
    }

    public async Task<Organization> FindByIdAsync(int id)
    {
        return await _context.Organizations.FindAsync(id);
    }
}