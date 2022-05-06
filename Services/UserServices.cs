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

    public User? GetUser(string name, string password)
    {
        return _databaseContext.Users
            .AsNoTracking()
            .SingleOrDefault(user => user.Name == name && user.Password == password);
    }

    public User Create(User newUser)
    {
        _databaseContext.Users.Add(newUser);
        _databaseContext.SaveChanges();

        return newUser;
    }

    public void UpdateUserName(int id, User user)
    {
        var userToUpdate = _databaseContext.Users.Find(id);

        if(userToUpdate is null)
            throw new NullReferenceException("User does not exists!");
        
        userToUpdate.Name = user.Name;
        _databaseContext.SaveChanges();
    }

    public void UpdatePassword(int id, User user)
    {
        var userToUpdate = _databaseContext.Users.Find(id);

        if(userToUpdate is null)
            throw new NullReferenceException("User does not exists!");
        
        userToUpdate.Password = user.Password;
        _databaseContext.SaveChanges();
    }
}