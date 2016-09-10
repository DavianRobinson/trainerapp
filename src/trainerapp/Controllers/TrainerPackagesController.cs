using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trainerapp.Data;
using trainerapp.Models.TrainerAppModels;

namespace trainerapp.Controllers
{
    public class TrainerPackagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainerPackagesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: TrainerPackages
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrainerPackage.ToListAsync());
        }

        // GET: TrainerPackages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainerPackage = await _context.TrainerPackage.SingleOrDefaultAsync(m => m.TrainerPackageId == id);
            if (trainerPackage == null)
            {
                return NotFound();
            }

            return View(trainerPackage);
        }

        // GET: TrainerPackages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainerPackages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainerPackageId,Description,MinimumContractPeriod,Period,Price,TrainerPackageName")] TrainerPackage trainerPackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainerPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(trainerPackage);
        }

        // GET: TrainerPackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainerPackage = await _context.TrainerPackage.SingleOrDefaultAsync(m => m.TrainerPackageId == id);
            if (trainerPackage == null)
            {
                return NotFound();
            }
            return View(trainerPackage);
        }

        // POST: TrainerPackages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrainerPackageId,Description,MinimumContractPeriod,Period,Price,TrainerPackageName")] TrainerPackage trainerPackage)
        {
            if (id != trainerPackage.TrainerPackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainerPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainerPackageExists(trainerPackage.TrainerPackageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(trainerPackage);
        }

        // GET: TrainerPackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainerPackage = await _context.TrainerPackage.SingleOrDefaultAsync(m => m.TrainerPackageId == id);
            if (trainerPackage == null)
            {
                return NotFound();
            }

            return View(trainerPackage);
        }

        // POST: TrainerPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainerPackage = await _context.TrainerPackage.SingleOrDefaultAsync(m => m.TrainerPackageId == id);
            _context.TrainerPackage.Remove(trainerPackage);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TrainerPackageExists(int id)
        {
            return _context.TrainerPackage.Any(e => e.TrainerPackageId == id);
        }
    }
}
