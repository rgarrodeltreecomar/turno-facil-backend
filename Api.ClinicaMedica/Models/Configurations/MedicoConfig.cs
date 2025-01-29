using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ClinicaMedica.Models.Configurations
{
    public class MedicoConfig : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.Property(m => m.Sueldo).HasPrecision(18, 2);
            builder.Property(m => m.Activo).HasDefaultValue(true);
        }
    }
}