using Api.ClinicaMedica.AccesoDatos;
using Api.ClinicaMedica.Entities;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;
using System.Linq;
namespace Api.ClinicaMedica.Servicios
    
{
    public class ConsultaServicio
    {
        private readonly ApplicationDbContext _context;
        // Constructor: Recibe el contexto de la base de datos (inyección de dependencias)
        public ConsultaServicio(ApplicationDbContext context)
        {
            _context = context;

        }
        // Método para crear una consulta con lógica de paquetes
        public async Task<Consultas> CrearConsultasAsync(Consultas consulta, List<string> serviciosId)

        {
            if (serviciosId == null || serviciosId.Count == 0)
                throw new ArgumentException("Debe seleccionar al menos un servicio");

            // Lógica para múltiples servicios
            if (serviciosId.Count > 1)
            {
                var servicio = await _context.Servicios.
                               Where(s => serviciosId.Contains(s.IdServicio))
                               .ToListAsync();

                // Validar que todos los servicios existen

                if (servicio.Count != serviciosId.Count)
                    throw new KeyNotFoundException("Uno o más servicios no existen");

                // Paso 2: Buscar o crear paquete
                var paqueteExistente = await BuscarPaqueteExistenteAsync(servicio);

                if (paqueteExistente == null)
                {
                    paqueteExistente = new Paquetes
                    {
                        CodigoPaquete = $"PAQ-{Guid.NewGuid().ToString().Substring(0, 8)}",
                        Nombre = "Paquete personalizado",
                        PaqueteServicios = servicio.Select(s => new PaqueteServicio
                        {
                            CodigoServicio = s.IdServicio
                        }).ToList()
                    };

                    // Calcular precio con 15% de descuento
                    paqueteExistente.CalcularPrecio(servicio);
                    _context.Paquetes.Add(paqueteExistente);
                }

                // Paso 3: Asignar paquete a la consulta
                consulta.IdPaquete = paqueteExistente.CodigoPaquete;
                consulta.MontoTotal = paqueteExistente.PrecioPaquete;

                // Paso 4: Aplicar 20% adicional por obra social
                if (consulta.ObraSocial)
                    consulta.MontoTotal *= 0.80m;
            }
            else
            {
                // Lógica para un solo servicio
                var servicio = await _context.Servicios
                    .FirstOrDefaultAsync(s => s.IdServicio == serviciosId.First());

                if (servicio == null)
                    throw new KeyNotFoundException("Servicio no encontrado");

                consulta.IdServicio = servicio.IdServicio;
                consulta.MontoTotal = servicio.Precio;
            }

            await _context.SaveChangesAsync();
            return consulta;
        }
        // Método auxiliar para buscar paquetes existentes
        private async Task<Paquetes> BuscarPaqueteExistenteAsync(List<Servicio> servicio)
        {
            var IdServicio = servicio.Select(s => s.IdServicio).OrderBy(id => id).ToList();

            // Buscar paquetes con la misma cantidad de servicios
            var paquetesCandidatos = await _context.Paquetes
                .Include(p => p.PaqueteServicios)
                .Where(p => p.PaqueteServicios.Count == servicio.Count)
                .ToListAsync();

            foreach (var paquete in paquetesCandidatos)
            {
                var IdPaquete = paquete.PaqueteServicios
                    .Select(ps => ps.CodigoServicio)
                    .OrderBy(id => id)
                    .ToList();

                if (IdPaquete.SequenceEqual(IdServicio))
                    return paquete;
            }

            return null;
        }
    }
}


// Método auxiliar para buscar paquetes existentes



