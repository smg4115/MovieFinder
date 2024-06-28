namespace MovieFinder.Models.User;

public class UserDetail
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateCreated { get; set; }
}