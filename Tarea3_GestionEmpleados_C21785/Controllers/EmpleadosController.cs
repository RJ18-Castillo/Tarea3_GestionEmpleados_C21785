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

        public IActionResult Index(string? busqueda, int pagina = 1)
        {
            var empleados = _repo.ObtenerPaginado(pagina, TAMANO_PAGINA, busqueda);
            var total = _repo.ContarTotal(busqueda);

            ViewBag.Busqueda = busqueda;
            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = (int)Math.Ceiling((double)total / TAMANO_PAGINA);
            ViewBag.TotalRegistros = total;

            return View(empleados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                empleado.Activo = true;
                _repo.Agregar(empleado);
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        public IActionResult Edit(int id)
        {
            var emp = _repo.ObtenerPorId(id);
            if (emp == null) return NotFound();

            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _repo.Actualizar(empleado);
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        [HttpPost]
        public IActionResult ToggleActivo(int id)
        {
            _repo.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}