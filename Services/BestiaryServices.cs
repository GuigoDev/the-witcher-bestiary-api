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

    public Beast Create(Beast newBeast)
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
        
        beastToUpdate.Name = beast.Name;
        beastToUpdate.Description = beast.Description;
        beastToUpdate.Variations = beast.Variations;
        beastToUpdate.Occurrences = beast.Occurrences;
        beastToUpdate.Vulnerable = beast.Vulnerable;
        beastToUpdate.Immunity = beast.Immunity;
        beastToUpdate.Loot = beast.Loot;

        _databaseContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var beastToDelete = _databaseContext.Beasts.Find(id);

        if(beastToDelete is not null)
            _databaseContext.Beasts.Remove(beastToDelete);
            _databaseContext.SaveChanges();
    }
}