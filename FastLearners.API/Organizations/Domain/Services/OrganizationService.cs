using FastLearners.API.Organizations.Domain.Models;
using FastLearners.API.Organizations.Domain.Repositories;
using FastLearners.API.Organizations.Domain.Services.Communication;
using FastLearners.API.Shared.Domain.Repositories;

namespace FastLearners.API.Organizations.Domain.Services;

 public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrganizationService(IOrganizationRepository organizationRepository, IUnitOfWork unitOfWork)
        {
            _organizationRepository = organizationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Organization>> ListAsync()
        {
            return await _organizationRepository.ListAsync();
        }

        public async Task<OrganizationResponse> SaveAsync(Organization organization)
        {
            try
            {
                organization.CreatedAt = DateTime.UtcNow;
                organization.UpdatedAt = DateTime.UtcNow;

                await _organizationRepository.AddAsync(organization);
                await _unitOfWork.CompleteAsync();

                return new OrganizationResponse(organization);
            }
            catch (Exception ex)
            {
              
                return new OrganizationResponse($"An error occurred when saving the user: {ex.Message}");
            }
        }

       

        public async Task<OrganizationResponse> UpdateAsync(int id, Organization organization)
        {
            var existingOrganization = await _organizationRepository.FindByIdAsync(id);

            if (existingOrganization == null)
            {
                return new OrganizationResponse("Organization not found.");
            }

            existingOrganization.Name = organization.Name;
            existingOrganization.Description = organization.Description;
            existingOrganization.TopicName = organization.TopicName;

            try
            {
                _organizationRepository.Update(existingOrganization);
                await _unitOfWork.CompleteAsync();

                return new OrganizationResponse(existingOrganization);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones y registro
                return new OrganizationResponse($"An error occurred when updating the organization: {ex.Message}");
            }
        }

        public async Task<OrganizationResponse> DeleteAsync(int id)
        {
            var organization = await _organizationRepository.FindByIdAsync(id);

            if (organization == null)
            {
                return new OrganizationResponse("Organization not found.");
            }

            try
            {
                _organizationRepository.Remove(organization);
                await _unitOfWork.CompleteAsync();

                return new OrganizationResponse(organization);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones y registro
                return new OrganizationResponse($"An error occurred when deleting the organization: {ex.Message}");
            }
        }

        public async Task<Organization> FindByIdAsync(int id)
        {
            return await _organizationRepository.FindByIdAsync(id);
        }
    }