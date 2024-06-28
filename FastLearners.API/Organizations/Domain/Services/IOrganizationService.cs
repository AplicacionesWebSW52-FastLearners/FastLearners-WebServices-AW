using FastLearners.API.Organizations.Domain.Models;
using FastLearners.API.Organizations.Domain.Services.Communication;

namespace FastLearners.API.Organizations.Domain.Services;

public interface IOrganizationService
{
    Task<IEnumerable<Organization>> ListAsync();
    Task<OrganizationResponse> SaveAsync(Organization organization);
    Task<OrganizationResponse> UpdateAsync(int id, Organization organization);
    Task<OrganizationResponse> DeleteAsync(int id);
    Task<Organization> FindByIdAsync(int id);
}