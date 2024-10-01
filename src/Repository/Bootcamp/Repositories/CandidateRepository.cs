using Dapper;
using Domain.Interfaces.Repository.Bootcamp;
using Domain.Models;
using System.Data;

namespace Repository.Bootcamp.Repositories;

public class CandidateRepository : ICandidateRepository
{
    private readonly IUnitOfWorkBootcamp _unitOfWork;
    private IDbConnection Connection => _unitOfWork.Connection;
    private IDbTransaction Transaction => _unitOfWork.Transaction;

    public CandidateRepository(IUnitOfWorkBootcamp unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Insert(Candidate candidate)
    {
        candidate.Id = Guid.NewGuid();
        string query = @"INSERT INTO Candidate
                            (ID
                            ,Name
                            ,Email
                            ,Cpf
                            ,BirthDate)
                        VALUES
                            (@id
                            ,@name
                            ,@email
                            ,@cpf
                            ,@birthDate)";
        var param = (candidate.Id, candidate.Name, candidate.Email, candidate.Cpf, candidate.BirthDate);
        var result = await Connection.ExecuteAsync(query, param, Transaction);
        return result > 0 ? candidate.Id : Guid.Empty;
    }
    public async Task<IList<Candidate>> GetAll()
    {
        string query = @"SELECT c.Id
                                ,c.Name
                                ,c.Email
                                ,c.Cpf
                                ,c.BirthDate
                                ,c.Active
                                ,c.Deleted
                                ,c.CreatedAt
                        FROM Candidate c";
        return (await Connection.QueryAsync<Candidate>(query, transaction: _unitOfWork.Transaction)).ToList();
    }
    public async Task<Candidate> GetById(Guid id)
    {
        string query = @"SELECT c.Id
                                ,c.Name
                                ,c.Email
                                ,c.Cpf
                                ,c.BirthDate
                                ,c.Active
                                ,c.Deleted
                                ,c.CreatedAt
                        FROM Candidate c
                        WHERE Id = @id";
        return await Connection.QueryFirstOrDefaultAsync<Candidate>(query, new { id }, Transaction);
    }

    public async Task<bool> Update(Candidate candidate)
    {
        string query = @"UPDATE Candidate
                            set Name = @name
                                ,Email = @email
                                ,Cpf = @cpf
                                ,BirthDate = @birthDate
                                ,Active = @active
                                ,Deleted = @deleted
                        WHERE Id = @id";
        var param = (candidate.Id, candidate.Name, candidate.Email, candidate.Cpf, candidate.BirthDate, candidate.Active, candidate.Deleted);
        var result = await Connection.ExecuteAsync(query, param, Transaction);
        return result > 0;
    }

    public async Task<bool> Delete(Guid id)
    {
        string query = @"DELETE FROM Candidate WHERE Id = @id";
        var param = new { id };
        var result = await Connection.ExecuteAsync(query, param, Transaction);
        return result > 0;
    }
}
