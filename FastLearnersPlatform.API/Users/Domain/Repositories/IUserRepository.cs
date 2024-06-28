using FastLearnersPlatform.API.Users.Domain.Model;

namespace FastLearnersPlatform.API.Users.Domain.Repositories;

public interface IUserRepository
{
    Task<User> FindByEmailAsync(string email);
    Task AddAsync(User user);
    // Otros métodos necesarios, como FindByIdAsync, etc.
}   
