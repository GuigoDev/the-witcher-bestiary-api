using BestiaryApi.Models;
using BestiaryApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BestiaryApi.Services;

public class BestiaryServices
{
    private readonly DatabaseContext _databaseContext;

    public BestiaryServices(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public IEnumerable<Beast> GetAll()
    {
        return _databaseContext.Beasts
            .AsNoTracking()
            .ToList();
    }

    public Beast? GetById(int id)
    {
        return _databaseContext.Beasts
            .AsNoTracking()
            .SingleOrDefault(beast => beast.Id == id);
    }

    public Beast Create(int id, Beast newBeast)
    {
        _databaseContext.Beasts.Add(newBeast);
        _databaseContext.SaveChanges();

        return newBeast;
    }

    public void Update(int id, Beast beast)
    {
        var beastToUpdate = _databaseContext.Beasts.Find(id);

        if(beastToUpdate is null)
            throw new NullReferenceException("Beast does not exists!");
        
        beastToUpdate = beast;

        _databaseContext.SaveChanges();
    }
}