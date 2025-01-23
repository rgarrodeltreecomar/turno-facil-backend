using Api.ClinicaMedica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ClinicaMedica.Models.Configurations
{
    public class TurnoConfig : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> builder)
        {
            builder.Property(t => t.FechaConsulta).HasColumnType("date");
            builder.Property(t => t.Precio).HasPrecision(18, 2);
            builder.Property(t => t.Abonado).HasDefaultValue(false);
        }
    }
}