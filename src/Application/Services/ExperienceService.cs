using Application.Services.Interface;
using Domain.Interfaces.Repository.Bootcamp;
using Domain.Models;

namespace Application.Services;

class ExperienceService : IExperienceService
{
    private readonly IUnitOfWorkBootcamp _unitOfWorkBootcamp;

    public ExperienceService(IUnitOfWorkBootcamp unitOfWorkBootcamp)
    {
        _unitOfWorkBootcamp = unitOfWorkBootcamp;
    }

    public async Task<IList<Experience>> GetAll()
    {
        return await _unitOfWorkBootcamp.Experience.GetAll();
    }

    public async Task<IList<Experience>> GetByCpf(string cpf)
    {
        return await _unitOfWorkBootcamp.Experience.GetByCpf(cpf);
    }
}
