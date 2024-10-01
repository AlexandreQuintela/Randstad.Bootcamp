namespace Domain.Interfaces.Repository.Base;

using System;
using System.Data;

/// <summary>
/// Interface que define o contrato para o padrão Unit of Work.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Obtém a conexão de banco de dados utilizada pela unidade de trabalho.
    /// </summary>
    IDbConnection Connection { get; }

    /// <summary>
    /// Obtém a transação atual da unidade de trabalho.
    /// </summary>
    IDbTransaction Transaction { get; }

    /// <summary>
    /// Obtém ou define a string de conexão para o banco de dados.
    /// </summary>
    string ConnectionString { get; set; }

    /// <summary>
    /// Inicia uma nova transação no contexto da unidade de trabalho.
    /// </summary>
    void BeginTransaction();

    /// <summary>
    /// Confirma todas as operações realizadas dentro da transação atual.
    /// </summary>
    void Commit();

    /// <summary>
    /// Reverte todas as operações realizadas dentro da transação atual.
    /// </summary>
    void Rollback();
}