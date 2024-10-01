using Dapper;
using Domain.Interfaces.Repository.Bootcamp;
using Domain.Models;
using System.Data;

namespace Repository.Bootcamp.Repositories;

public class ExperienceRepository : IExperienceRepository
{
    private readonly IUnitOfWorkBootcamp _unitOfWork;
    private IDbConnection Connection => _unitOfWork.Connection;
    private IDbTransaction Transaction => _unitOfWork.Transaction;
    public ExperienceRepository(IUnitOfWorkBootcamp unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IList<Experience>> GetAll()
    {
        string query = @"SELECT e.Id
                                ,e.Ocupation
                                ,e.CompanyName
                                ,e.StartDate
                                ,e.EndDate
                                ,e.Deleted
                                ,e.CreatedAt
                        FROM Experience e";
        return (await Connection.QueryAsync<Experience>(query, transaction: _unitOfWork.Transaction)).ToList();
    }

    public async Task<IList<Experience>> GetByCpf(string cpf)
    {
        string query = @"SELECT e.Id
                                ,e.Ocupation
                                ,e.CompanyName
                                ,e.StartDate
                                ,e.EndDate
                                ,e.Deleted
                                ,e.CreatedAt
                        FROM Candidate c
                        INNER JOIN CandidateExperience ce ON c.Id = ce.CandidateId
                        INNER JOIN Experience e on e.Id = ce.ExperienceId
                        WHERE c.Cpf = @cpf";
        return (await Connection.QueryAsync<Experience>(query, new { cpf }, _unitOfWork.Transaction)).ToList();
    }
}
