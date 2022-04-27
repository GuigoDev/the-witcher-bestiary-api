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

    [Required]
    public string? Variations { get; set; }

    [Required]
    public string? Occurrences { get; set; }

    [Required]
    public string? Vulnerable { get; set; }

    [Required]
    public string? Immunity { get; set; }

    [Required]
    public string? Loot { get; set; }
}