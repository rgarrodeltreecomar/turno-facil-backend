using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Api.ClinicaMedica.Models.Configurations
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.Nombre).HasMaxLength(50);
            builder.Property(u => u.Apellido).HasMaxLength(50);
            builder.Property(u => u.Dni).HasMaxLength(15);
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(u => u.FechaNac).HasColumnType("date");
            builder.Property(u => u.Telefono).HasMaxLength(50);
            builder.Property(u => u.Direccion).HasMaxLength(50);

        }
    }
}

