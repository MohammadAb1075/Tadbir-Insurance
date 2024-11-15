using Core.Enums;
using Core.Models;
using Infrastrucrure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Config;

internal class CoverageTypeConfig : IEntityTypeConfiguration<CoverageTypeModel>
{
    public void Configure(EntityTypeBuilder<CoverageTypeModel> builder)
    {
        builder.HasKey(x => x.Id)
               .HasName("PK_CoverageType");
     
        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasData(EnumUtil.GetValues<CoverageType>()
                                .Select(x => new CoverageTypeModel
                                {
                                    Id = x.Value,
                                    Name = x.Name
                                }));
    }
}
