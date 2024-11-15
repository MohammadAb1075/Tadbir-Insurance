using Core.Enums;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config;

internal class CoverageConfig : IEntityTypeConfiguration<CoverageModel>
{
    public void Configure(EntityTypeBuilder<CoverageModel> builder)
    {
        builder
            .HasKey(x => x.Id)
            .HasName("PK_Coverage");

        builder.HasOne(x => x.CoverageType)
               .WithMany(y => y.Coverages)
               .HasForeignKey(z => z.CoverageTypeId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Coverage_CoverageType");

        builder.HasData(
        [
            new CoverageModel { Id = 1, CoverageTypeId = (int)CoverageType.Surgery, MinAmount = 5000, MaxAmount = 500000000, Rate = 0.0052 },
            new CoverageModel { Id = 2, CoverageTypeId = (int)CoverageType.Dentistry, MinAmount = 4000, MaxAmount = 400000000, Rate = 0.0042 },
            new CoverageModel { Id = 3, CoverageTypeId = (int)CoverageType.Hospitalization, MinAmount = 2000, MaxAmount = 200000000, Rate = 0.005 }
        ]);
    }
}
