using System.Threading.Tasks;
using FastLearnersPlatform.API.Users.Domain.Model;
using FastLearnersPlatform.API.Users.Domain.Repositories;
using FastLearnersPlatform.API.Users.Domain.Services;

using BCrypt.Net;

namespace FastLearnersPlatform.API.Users.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> AuthenticateAsync(string email, string password)
    {
        var user = await _userRepository.FindByEmailAsync(email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            return new UserResponse("Invalid email or password.");

        return new UserResponse(user);
    }

    public async Task<UserResponse> RegisterAsync(string email, string password, string firstName, string lastName, string idMembership)
    {
        var existingUser = await _userRepository.FindByEmailAsync(email);

        if (existingUser != null)
            return new UserResponse("Email already taken.");

        var user = new User
        {
            Email = email,
            Password = BCrypt.Net.BCrypt.HashPassword(password),
            FirstName = firstName,
            LastName = lastName,
            IdMembership = idMembership
        };

        try
        {
            await _userRepository.AddAsync(user);
            return new UserResponse(user);
        }
        catch (Exception ex)
        {
            return new UserResponse($"An error occurred when saving the user: {ex.Message}");
        }
    }
}