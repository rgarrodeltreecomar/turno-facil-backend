using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ClinicaMedica.Models.Configurations
{
    public class PaqueteConfig : IEntityTypeConfiguration<Paquete>
    {
        public void Configure(EntityTypeBuilder<Paquete> builder)
        {
            builder.Property(p => p.Precio).HasPrecision(18, 2);

        }
    }
}
