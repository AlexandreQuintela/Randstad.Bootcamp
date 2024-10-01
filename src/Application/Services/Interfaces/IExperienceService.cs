using Domain.Models;

namespace Application.Services.Interface;

public interface IExperienceService
{
    Task<IList<Experience>> GetAll();
    Task<IList<Experience>> GetByCpf(string cpf);
}
