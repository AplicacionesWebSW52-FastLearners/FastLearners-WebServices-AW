using FastLearners.API.Shared.Domain.Repositories;
using FastLearners.API.Users.Domain.Models;
using FastLearners.API.Users.Domain.Repositories;
using FastLearners.API.Users.Domain.Services.Communication;

namespace FastLearners.API.Users.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<UserResponse> SaveAsync(User user)
    {
        try
        {
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            return new UserResponse(user);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new UserResponse($"An error occurred when saving the user: {ex.Message}");
        }
    }

    public async Task<UserResponse> UpdateAsync(int id, User user)
    {
        var existingUser = await _userRepository.FindByIdAsync(id);

        if (existingUser == null)
            return new UserResponse("User not found.");

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;
        existingUser.MembershipId = user.MembershipId;
        existingUser.UpdatedAt = DateTime.UtcNow;

        try
        {
            _userRepository.Update(existingUser);
            await _unitOfWork.CompleteAsync();

            return new UserResponse(existingUser);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new UserResponse($"An error occurred when updating the user: {ex.Message}");
        }
    }

    public async Task<UserResponse> DeleteAsync(int id)
    {
        var existingUser = await _userRepository.FindByIdAsync(id);

        if (existingUser == null)
            return new UserResponse("User not found.");

        try
        {
            _userRepository.Remove(existingUser);
            await _unitOfWork.CompleteAsync();

            return new UserResponse(existingUser);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new UserResponse($"An error occurred when deleting the user: {ex.Message}");
        }
    }

    public async Task<User> FindByIdAsync(int id)
    {
        return await _userRepository.FindByIdAsync(id);
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        return await _userRepository.FindByEmailAsync(email);
    }
}