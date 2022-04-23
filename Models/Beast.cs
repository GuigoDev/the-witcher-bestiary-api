using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bestiary.Models;

 public class Beast
{
     [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Variations { get; set; } = null!;

    public string Occurrences { get; set; } = null!;

    public string Vulnerable { get; set; } = null!;

    public string Immunity { get; set; } = null!;

    public string Loot { get; set; } = null!;
}
