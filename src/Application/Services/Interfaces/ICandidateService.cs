using Domain.Models;

namespace Application.Services.Interface;

public interface ICandidateService
{
    Task<Guid> Create(Candidate candidate);
    Task<bool> Update(Candidate candidate);
    Task<bool> Delete(Guid id);
    Task<IList<Candidate>> GetAll();
    Task<Candidate> GetById(Guid id);
}
