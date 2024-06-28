using FastLearners.API.Organizations.Domain.Models;
using FastLearners.API.Organizations.Domain.Services.Communication;

namespace FastLearners.API.Organizations.Domain.Services.Communication;
public class OrganizationResponse : BaseResponse
{
    public Organization Organization { get; private set; }

    private OrganizationResponse(bool success, string message, Organization organization) : base(success, message)
    {
        Organization = organization;
    }

    public OrganizationResponse(Organization organization) : this(true, string.Empty, organization)
    { }

    public OrganizationResponse(string message) : this(false, message, null)
    { }
}