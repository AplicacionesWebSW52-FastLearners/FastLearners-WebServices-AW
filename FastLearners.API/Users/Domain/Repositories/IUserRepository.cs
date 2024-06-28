namespace FastLearners.API.Users.Domain.Repositories;
using FastLearners.API.Users.Domain.Models;
public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task<User> FindByIdAsync(int id);
    Task<User> FindByEmailAsync(string email);
    Task AddAsync(User user);
    Task Update(User existingUser);
    Task Remove(User existingUser);
    Task SaveChangesAsync();


   
}