using System.Threading.Tasks;
using FastLearnersPlatform.API.Users.Domain.Model;
using FastLearnersPlatform.API.Users.Domain.Services;

namespace FastLearnersPlatform.API.Users.Domain.Services;
public interface IUserService
{
    Task<UserResponse> AuthenticateAsync(string email, string password);
    Task<UserResponse> RegisterAsync(string email, string password, string firstName, string lastName, string idMembership);
}   
