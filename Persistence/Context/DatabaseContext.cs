using Core.Enums;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Config;

namespace Persistence.Context;

public class DatabaseContext : DbContext
{
#pragma warning disable CS8618 
    public DatabaseContext
#pragma warning restore CS8618 
        (DbContextOptions<DatabaseContext> options) : base(options: options)
    {

        Database.EnsureCreated();
    }

    public DbSet<CoverageModel> Coverages { get; set; }
    public DbSet<CoverageTypeModel> CoverageTypes { get; set; }
    public DbSet<InsuranceModel> Insurances { get; set; }
    public DbSet<InsuranceCoverageModel> InsuranceCoverages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(assembly: typeof(CoverageConfig).Assembly);
    }
}
