using FastLearners.API.Organizations.Domain.Models;

namespace FastLearners.API.Organizations.Domain.Repositories;

public interface IOrganizationRepository
{
    Task<IEnumerable<Organization>> ListAsync();
    Task AddAsync(Organization organization);
    void Update(Organization organization);
    void Remove(Organization organization);
    Task<Organization> FindByIdAsync(int id);
}