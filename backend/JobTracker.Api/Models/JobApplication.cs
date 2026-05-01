namespace JobTracker.Api.Models;

public class JobApplication
{
    public int Id { get; set; }
    
    public string CompanyName { get; set; } = string.Empty;

    public string Position { get; set; } = string.Empty;

    public string Status { get; set; } = "Applied";

    public DateTime DateApplied { get; set; } = DateTime.UtcNow;

    public string? Notes { get; set; }

    public int UserId { get; set; }
    public User User {get; set; } = null!;
}