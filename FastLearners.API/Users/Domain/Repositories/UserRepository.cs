using FastLearners.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace FastLearners.API.Users.Domain.Repositories;
using FastLearners.API.Users.Domain.Models;
using FastLearners.API.Shared.Domain.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User> FindByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task Update(User user)
    {
        _context.Users.Update(user);
    }

    public async Task Remove(User user)
    {
        _context.Users.Remove(user);
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}