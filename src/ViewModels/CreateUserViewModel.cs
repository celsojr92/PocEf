using System.ComponentModel.DataAnnotations;

namespace PocEf.ViewModels;

public sealed class CreateUserViewModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }
}