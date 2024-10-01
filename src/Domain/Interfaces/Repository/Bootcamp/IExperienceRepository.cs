using Domain.Models;

namespace Domain.Interfaces.Repository.Bootcamp;

public interface IExperienceRepository
{
    Task<IList<Experience>> GetAll();
    Task<IList<Experience>> GetByCpf(string cpf);
}
