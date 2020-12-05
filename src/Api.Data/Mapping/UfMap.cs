using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Api.Domain.Entities;

namespace Api.Data.Mapping
{
    public class UfMap : IEntityTypeConfiguration<UfEntity>
    {
        public void Configure(EntityTypeBuilder<UfEntity> builder)
        {
            builder.ToTable("Uf");
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Sigla).IsUnique();
        }
    }
}
