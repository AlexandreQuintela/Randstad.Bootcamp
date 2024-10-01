using Domain.Models;

namespace Domain.Interfaces.Repository.Bootcamp;

public interface ICandidateRepository
{
    Task<Guid> Insert(Candidate candidate);
    Task<IList<Candidate>> GetAll();
    Task<Candidate> GetById(Guid id);
    Task<bool> Update(Candidate candidate);
    Task<bool> Delete(Guid id);
}
