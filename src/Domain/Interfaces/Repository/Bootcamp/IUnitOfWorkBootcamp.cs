using Domain.Interfaces.Repository.Base;

namespace Domain.Interfaces.Repository.Bootcamp;

public interface IUnitOfWorkBootcamp : IUnitOfWork
{
    ICandidateRepository Candidate { get; }
    IExperienceRepository Experience { get; }
}
