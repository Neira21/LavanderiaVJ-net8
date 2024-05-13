using LavanderiaVJWeb.Data;
using LavanderiaVJWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LavanderiaVJWeb.Controllers
{
    public class ServiciosDisponiblesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ServiciosDisponiblesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            // Lista tomada de la base de datos y order by name
            //List<ServiciosDisponibles> objClass = _db.ServiciosDisponibles.OrderBy(c => c.NombreSer).ToList();
            List<ServiciosDisponibles> objServiciosDisponibles = _db.ServiciosDisponibles.ToList();

            return View(objServiciosDisponibles);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ServiciosDisponibles obj)
        {

            if(obj.NombreSer != null && obj.NombreSer.ToLower() == "servicio"){
                ModelState.AddModelError("NombreSer", "El nombre del servicio no puede ser 'Servicio'");
            }

            if (ModelState.IsValid)
            {
                _db.ServiciosDisponibles.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            ServiciosDisponibles SerDis = _db.ServiciosDisponibles.Find(id);
            if(SerDis == null)
            {
                return NotFound();
            }
            return View(SerDis);
        }
        [HttpPost]
        public IActionResult Edit(ServiciosDisponibles obj)
        {
            if (obj.NombreSer != null && obj.NombreSer.ToLower() == "servicio")
            {
                ModelState.AddModelError("NombreSer", "El nombre del servicio no puede ser 'Servicio'");
            }

            if (ModelState.IsValid)
            {
                _db.ServiciosDisponibles.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ServiciosDisponibles? SerDis = _db.ServiciosDisponibles.Find(id);
            if (SerDis == null)
            {
                return NotFound();
            }
            return View(SerDis);
        }

        [HttpPost]
        [ActionName("delete")]
        public IActionResult deleteService(int? id)
        {
            ServiciosDisponibles? SerDis = _db.ServiciosDisponibles.Find(id);
            if (SerDis == null)
            {
                return NotFound();
            }
            _db.ServiciosDisponibles.Remove(SerDis);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
