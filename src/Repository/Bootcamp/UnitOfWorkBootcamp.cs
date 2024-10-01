using Domain.Interfaces.Repository.Bootcamp;
using Microsoft.Extensions.Configuration;
using Repository.Base;
using Repository.Bootcamp.Repositories;
using System.Data.SqlClient;

namespace Repository.Bootcamp;

public class UnitOfWorkBootcamp : UnitOfWork<SqlConnection>, IUnitOfWorkBootcamp
{
    public ICandidateRepository Candidate => new CandidateRepository(this);
    public IExperienceRepository Experience => new ExperienceRepository(this);

    public UnitOfWorkBootcamp(IConfiguration config)
    {
        ConnectionString = config.GetConnectionString("BootcampConnection");
    }
}
