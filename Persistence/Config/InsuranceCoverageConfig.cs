using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config;

internal class InsuranceCoverageConfig : IEntityTypeConfiguration<InsuranceCoverageModel>
{
    public void Configure(EntityTypeBuilder<InsuranceCoverageModel> builder)
    {
        builder.HasKey(x => x.Id)
               .HasName("PK_InsuranceCoverage");

        builder.HasOne(x => x.Insurance)
               .WithMany(y => y.InsuranceCoverages)
               .HasForeignKey(z => z.InsuranceId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Insurance_Coverage_Insurance");

        builder.HasOne(x => x.Coverage)
               .WithMany(y => y.InsuranceCoverages)
               .HasForeignKey(z => z.CoverageId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Insurance_Coverage_Coverage");
    }
}