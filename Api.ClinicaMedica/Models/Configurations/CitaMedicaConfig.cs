using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Api.ClinicaMedica.Models.Configurations
{
    public class CitaMedicaConfig : IEntityTypeConfiguration<CitaMedica>
    {
        public void Configure(EntityTypeBuilder<CitaMedica> builder)
        {
          builder.Property(c => c.Precio).HasPrecision(18, 2);
        }
    }
}
