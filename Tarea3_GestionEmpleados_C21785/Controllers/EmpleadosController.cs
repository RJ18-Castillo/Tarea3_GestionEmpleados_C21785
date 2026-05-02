using Microsoft.AspNetCore.Mvc;
using Tarea3_GestionEmpleados_C21785.Models;
using Tarea3_GestionEmpleados_C21785.Repositories;

namespace Tarea3_GestionEmpleados_C21785.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoRepository _repo;
        private const int TAMANO_PAGINA = 5;

        public EmpleadosController(IEmpleadoRepository repo)
        {
            _repo = repo;
        }

        // 🔍 LISTADO + BÚSQUEDA + PAGINACIÓN
        public IActionResult Index(string? busqueda, int pagina = 1)
        {
            var empleados = _repo.ObtenerPaginado(pagina, TAMANO_PAGINA, busqueda);
            var totalRegistros = _repo.ContarTotal(busqueda);

            var totalPaginas = (int)Math.Ceiling((double)totalRegistros / TAMANO_PAGINA);

            ViewBag.Busqueda = busqueda;
            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = totalPaginas;
            ViewBag.TotalRegistros = totalRegistros;

            return View(empleados);
        }

        // 🆕 CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // 🆕 CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                empleado.Activo = true;
                _repo.Agregar(empleado);
                return RedirectToAction(nameof(Index));
            }

            return View(empleado);
        }

        // ✏️ EDIT (GET)
        public IActionResult Edit(int id)
        {
            var empleado = _repo.ObtenerPorId(id);

            if (empleado == null)
                return NotFound();

            return View(empleado);
        }

        // ✏️ EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _repo.Actualizar(empleado);
                return RedirectToAction(nameof(Index));
            }

            return View(empleado);
        }

        // 🔄 TOGGLE ACTIVO (BAJA LÓGICA)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleActivo(int id)
        {
            _repo.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}