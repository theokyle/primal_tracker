namespace MODELS.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public string? ImageUrl { get; set; }
    public required byte[] PasswordHash { get; set; }
    public List<Campaign> Campaigns { get; set; } = [];
}
