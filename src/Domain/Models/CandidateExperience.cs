namespace Domain.Models;

public class CandidateExperience
{
    public Guid Id { get; set; }
    public Guid CandidateId { get; set; }
    public Guid ExperienceId { get; set; }
}
