using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bestiary.Models;

 public class Beast
{
     [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public string? Variations { get; set; }

    public string? Occurrences { get; set; }

    public string? Vulnerable { get; set; }

    public string? Immunity { get; set; }

    public string? Loot { get; set; }
}
