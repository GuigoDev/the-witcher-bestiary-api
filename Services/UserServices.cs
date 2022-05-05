using BestiaryApi.Models;
using BestiaryApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BestiaryApi.Services;

public class UserServices
{
    private readonly DatabaseContext _databaseContext;

    public UserServices(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public IEnumerable<User> GetAll()
    {
        return _databaseContext.Users
            .AsNoTracking()
            .ToList();
    }

    public User? GetById(int id)
    {
        return _databaseContext.Users
            .AsNoTracking()
            .SingleOrDefault(user => user.Id == id);
    }

    public User Create(User newUser)
    {
        _databaseContext.Users.Add(newUser);
        _databaseContext.SaveChanges();

        return newUser;
    }
}