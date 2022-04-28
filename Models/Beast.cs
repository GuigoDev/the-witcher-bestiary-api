using System.ComponentModel.DataAnnotations;
namespace BestiaryApi.Models;

public class Beast
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    public string? Category { get; set; }

    public string? Variations { get; set; }

    public string? Occurrences { get; set; }

    public string? Vulnerable { get; set; }

    public string? Immunity { get; set; }

    public string? Loot { get; set; }
}