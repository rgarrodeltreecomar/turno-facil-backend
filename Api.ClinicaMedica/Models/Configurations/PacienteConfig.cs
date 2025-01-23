using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Models.Configurations
{
    public class PacienteConfig : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.Property(p => p.ObraSocial).HasDefaultValue(false);
            builder.Property(p => p.Activo).HasDefaultValue(true);
        }

    }
}
