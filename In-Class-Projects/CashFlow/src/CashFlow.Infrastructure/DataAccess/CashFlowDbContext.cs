using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;
public class CashFlowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; } // Mesmo nome da tabela; Da acesso a toda a tabela respectiva

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=cashflowdb;Uid=root;Pwd=@Password123";

        var version = new Version(8, 0, 42);

        var serverVersion = new MySqlServerVersion(version);

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
