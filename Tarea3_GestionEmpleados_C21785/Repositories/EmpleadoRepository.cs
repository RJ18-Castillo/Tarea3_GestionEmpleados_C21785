using Tarea3_GestionEmpleados_C21785.Data;
using Tarea3_GestionEmpleados_C21785.Models;

namespace Tarea3_GestionEmpleados_C21785.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly AppDbContext _context;

        public EmpleadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Empleado> ObtenerTodos()
        {
            return _context.Empleados.ToList();
        }

        public Empleado? ObtenerPorId(int id)
        {
            return _context.Empleados.Find(id);
        }

        public IEnumerable<Empleado> BuscarPorNombreODepartamento(string termino)
        {
            termino = termino.ToLower();

            return _context.Empleados
                .Where(e =>
                    e.Nombre.ToLower().Contains(termino) ||
                    e.Apellidos.ToLower().Contains(termino) ||
                    e.Departamento.ToLower().Contains(termino))
                .ToList();
        }

        public IEnumerable<Empleado> ObtenerPaginado(int pagina, int tamano, string? busqueda)
        {
            var query = _context.Empleados.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                var termino = busqueda.ToLower();

                query = query.Where(e =>
                    e.Nombre.ToLower().Contains(termino) ||
                    e.Apellidos.ToLower().Contains(termino) ||
                    e.Departamento.ToLower().Contains(termino));
            }

            return query
                .OrderBy(e => e.Id)
                .Skip((pagina - 1) * tamano)
                .Take(tamano)
                .ToList();
        }

        public int ContarTotal(string? busqueda)
        {
            var query = _context.Empleados.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                var termino = busqueda.ToLower();

                query = query.Where(e =>
                    e.Nombre.ToLower().Contains(termino) ||
                    e.Apellidos.ToLower().Contains(termino) ||
                    e.Departamento.ToLower().Contains(termino));
            }

            return query.Count();
        }

        public void Agregar(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
        }

        public void Actualizar(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var empleado = _context.Empleados.Find(id);

            if (empleado != null)
            {
                // 🔥 BAJA LÓGICA (esto lo pide la tarea)
                empleado.Activo = !empleado.Activo;
                _context.SaveChanges();
            }
        }
    }
}