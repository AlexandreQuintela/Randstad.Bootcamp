using Application.Services.Interface;
using Domain.Interfaces.Repository.Bootcamp;
using Domain.Models;

namespace Application.Services;

public class CandidateService : ICandidateService
{
    private readonly IUnitOfWorkBootcamp _unitOfWorkBootcamp;
    public CandidateService(IUnitOfWorkBootcamp unitOfWorkBootcamp)
    {
        _unitOfWorkBootcamp = unitOfWorkBootcamp;
    }
    public async Task<Guid> Create(Candidate candidate)
    {
        return await _unitOfWorkBootcamp.Candidate.Insert(candidate);
    }

    public async Task<bool> Delete(Guid id)
    {
        var candidateDeleted = await GetById(id);
        return candidateDeleted == null
            ? throw new ApplicationException("Candidato não encontrado")
            : await _unitOfWorkBootcamp.Candidate.Delete(id);
    }

    public async Task<IList<Candidate>> GetAll()
    {
        return await _unitOfWorkBootcamp.Candidate.GetAll();
    }

    public async Task<Candidate> GetById(Guid id)
    {
        return await _unitOfWorkBootcamp.Candidate.GetById(id);
    }

    public async Task<bool> Update(Candidate candidate)
    {
        var candidateUpdated = await GetById(candidate.Id);
        return candidateUpdated == null
            ? throw new ApplicationException("Candidato não encontrado")
            : await _unitOfWorkBootcamp.Candidate.Update(candidate);
    }
}
