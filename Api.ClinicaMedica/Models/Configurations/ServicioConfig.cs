using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ClinicaMedica.Models.Configurations
{
    public class ServicioConfig : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
            builder.Property(s => s.CodigoServicio).HasMaxLength(150);
            builder.Property(s => s.Nombre).HasMaxLength(50);
            builder.Property(s => s.Precio).HasPrecision(18, 2);
        }
    }
}
