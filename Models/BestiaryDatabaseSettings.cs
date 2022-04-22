namespace Bestiary.Models;

public class BestiaryDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string BestiaryCollectionName { get; set; } = null!;
}