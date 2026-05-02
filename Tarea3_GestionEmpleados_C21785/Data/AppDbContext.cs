using Microsoft.EntityFrameworkCore;
using Tarea3_GestionEmpleados_C21785.Models;

namespace Tarea3_GestionEmpleados_C21785.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
    }
}