using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LavanderiaVJWeb.Data;
using LavanderiaVJWeb.Models;

namespace LavanderiaVJWeb.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public IActionResult Index()
        {
            var clientes= _context.Clientes.Include(c => c.Distrito).ToList();
            return View(clientes);
        }

        // GET: Clientes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = _context.Clientes.Include(c => c.Distrito).FirstOrDefault(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewData["DistritoName"] = new SelectList(_context.Distritos, "Id", "Nombre");
            //var distritos = _context.Distritos.ToList
            //ViewBag.Distrito = distritos.Select(d => new SelectListItem(d.Nombre, d.Id.ToString()));
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nombre,Apellido,TipoDoc,NroDoc,Direccion,Email,DistritoId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (_context.Clientes.Any(a => a.NroDoc == cliente.NroDoc))
                {
                    ModelState.AddModelError("NroDoc", "Ya existe un Documento con este número");
                }
                else
                {
                    _context.Add(cliente);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["DistritoName"] = new SelectList(_context.Distritos, "Id", "Nombre", cliente.DistritoId);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["DistritoName"] = new SelectList(_context.Distritos, "Id", "Nombre", cliente.DistritoId);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nombre,Apellido,TipoDoc,NroDoc,Direccion,Email,DistritoId")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Buscar si existe otro cliente con el mismo número de documento
                var existingCliente = _context.Clientes.FirstOrDefault(a => a.NroDoc == cliente.NroDoc && a.Id != cliente.Id);

                if (existingCliente != null)
                {
                    // Si se encuentra otro cliente con el mismo número de documento, mostrar error
                    ModelState.AddModelError("NroDoc", "Ya existe un cliente con este número de documento.");
                }
                else
                {
                    // Si no hay duplicados, actualizar el cliente y guardar los cambios
                    _context.Update(cliente);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["DistritoName"] = new SelectList(_context.Distritos, "Id", "Nombre");
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.Distrito)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool ClienteExists(int id)
        //{
        //    return _context.Clientes.Any(e => e.Id == id);
        //}
    }
}
