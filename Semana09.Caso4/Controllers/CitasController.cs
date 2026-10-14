using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Semana09.Caso4.Models;

namespace Semana09.Caso4.Controllers
{
    public class CitasController : Controller
    {
        // lista en memoria (se borra al reiniciar la app)
        static List<Cita> citas = new List<Cita>();
        static int siguienteId = 1;

        void CargarEspecialidades()
        {
            ViewBag.Especialidades = new SelectList(new[] { "Medicina General", "Pediatria", "Cardiologia", "Dermatologia" });
        }

        public IActionResult Index()
        {
            return View(citas);
        }

        public IActionResult CreateHelpers()
        {
            CargarEspecialidades();
            ViewBag.Citas = citas;
            return View(new Cita());
        }

        public IActionResult CreateTagHelpers()
        {
            CargarEspecialidades();
            ViewBag.Citas = citas;
            return View(new Cita());
        }

        // las dos vistas envian aqui
        [HttpPost]
        public IActionResult Guardar(Cita cita, string vista)
        {
            if (!ModelState.IsValid)
            {
                CargarEspecialidades();
                ViewBag.Citas = citas;
                return View(vista, cita);
            }

            cita.Id = siguienteId++;
            citas.Add(cita);
            return RedirectToAction("Index");
        }

        public IActionResult Detalle(int id)
        {
            var cita = citas.FirstOrDefault(c => c.Id == id);
            if (cita == null) return NotFound();
            return View(cita);
        }
    }
}
