using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config;

internal class InsuranceConfig : IEntityTypeConfiguration<InsuranceModel>
{
    public void Configure(EntityTypeBuilder<InsuranceModel> builder)
    {
        builder.HasKey(x => x.Id)
               .HasName("PK_Insurance");

        builder.Property(x => x.Title)
               .IsRequired()
               .HasMaxLength(500);
    }
}
