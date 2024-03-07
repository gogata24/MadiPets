using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MadiPets.Db;
using MadiPets.Models;
using MadiPets.ViewModel;
using System.Reflection;

namespace MadiPets.Controllers
{
    public class PetsController : Controller
    {
        private readonly MadiPetsDbContext _context;

        public PetsController(MadiPetsDbContext context)
        {
            _context = context;
        }

        // GET: Pets
        public async Task<IActionResult> Index()
        {

              return _context.Pets != null ? 
                          View(await _context.Pets.ToListAsync()) :
                          Problem("Entity set 'MadiPetsDbContext.Pets'  is null.");
        }

        // GET: Pets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pets == null)
            {
                return NotFound();
            }

            var pets = await _context.Pets
                .FirstOrDefaultAsync(m => m.PetId == id);
            if (pets == null)
            {
                return NotFound();
            }

            return View(pets);
        }

        // GET: Pets/Create
        public IActionResult Create()
        {
            var model = new PetsFormViewModel();
            using (var db = new MadiPetsDbContext())
            {
                model.Users = db.Users.ToList();
                model.Types = db.Types.ToList();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(PetsViewModel model)
        {
            var pet = new Pets();
            pet.TypeId = model.TypeId;
            pet.Name = model.Name;
            pet.Description = model.Description;
            pet.Gender = model.Gender;
            pet.UserId = model.UserId;

            Random r = new Random();
            var fileName = r.Next() + DateTime.Now.ToString("yyyyMMddHHmm");
            var extension = model.Image.FileName.Split(".").Last();
            var fullName = $"{fileName}.{extension}";
            var webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fullName);
            model.Image.CopyTo(new FileStream(webRootPath, FileMode.Create));
            pet.ImagePath = $"/images/{fullName}";
            using (var db = new MadiPetsDbContext())
            {
                db.Pets.Add(pet);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");

        }

        // GET: Pets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pets == null)
            {
                return NotFound();
            }

            var pets = await _context.Pets.FindAsync(id);
            if (pets == null)
            {
                return NotFound();
            }
            return View(pets);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PetId,Name,Description,Gender,ImagePath")] Pets pets)
        {
            if (id != pets.PetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetsExists(pets.PetId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pets);
        }

        // GET: Pets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pets == null)
            {
                return NotFound();
            }

            var pets = await _context.Pets
                .FirstOrDefaultAsync(m => m.PetId == id);
            if (pets == null)
            {
                return NotFound();
            }

            return View(pets);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pets == null)
            {
                return Problem("Entity set 'MadiPetsDbContext.Pets'  is null.");
            }
            var pets = await _context.Pets.FindAsync(id);
            if (pets != null)
            {
                _context.Pets.Remove(pets);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetsExists(int id)
        {
          return (_context.Pets?.Any(e => e.PetId == id)).GetValueOrDefault();
        }
    }
}
