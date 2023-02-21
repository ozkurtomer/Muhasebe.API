using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Persistence.Contans;
using OnlineMuhasebe.Domain.CompanyEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineMuhasebe.Persistence.Configurations;

public sealed class UniformChartOfAccountConfiguration : IEntityTypeConfiguration<UniformChartOfAccount>
{
    public void Configure(EntityTypeBuilder<UniformChartOfAccount> builder)
    {
        builder.ToTable(TableName.UniformChartOfAccount);
        builder.HasKey(x => x.Id);
    }
}
