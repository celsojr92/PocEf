namespace PocEf.Models;

public sealed class User
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string Name { get; set; }
    public string Email { get; set; }
}