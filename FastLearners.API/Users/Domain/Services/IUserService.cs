using FastLearners.API.Users.Domain.Models;
using FastLearners.API.Users.Domain.Services.Communication;

namespace FastLearners.API.Users.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<UserResponse> SaveAsync(User user);
    Task<UserResponse> UpdateAsync(int id, User user);
    Task<UserResponse> DeleteAsync(int id);
    Task<User> FindByIdAsync(int id);
    Task<User> FindByEmailAsync(string email);
}