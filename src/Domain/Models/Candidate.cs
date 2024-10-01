namespace Domain.Models;

public class Candidate
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool Active { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedAt { get; set; }
}
