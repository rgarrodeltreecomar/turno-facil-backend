using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ClinicaMedica.Models.Configurations
{
    public class EspecialidadConfig : IEntityTypeConfiguration<Especialidad>
    {
        public void Configure(EntityTypeBuilder<Especialidad> builder)
        {
            builder.Property(e => e.Detalle).HasMaxLength(300);
        }
    }
}
