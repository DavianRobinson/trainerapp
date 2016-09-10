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
    public class ClientPackageSubscriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientPackageSubscriptionsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ClientPackageSubscriptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientPackageSubscriptions.ToListAsync());
        }

        // GET: ClientPackageSubscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientPackageSubscriptions = await _context.ClientPackageSubscriptions.SingleOrDefaultAsync(m => m.ClientPackageSubscriptionsId == id);
            if (clientPackageSubscriptions == null)
            {
                return NotFound();
            }

            return View(clientPackageSubscriptions);
        }

        // GET: ClientPackageSubscriptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientPackageSubscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientPackageSubscriptionsId,ClientId,PersonalTrainerId,TrainingPackageId")] ClientPackageSubscriptions clientPackageSubscriptions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientPackageSubscriptions);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clientPackageSubscriptions);
        }

        // GET: ClientPackageSubscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientPackageSubscriptions = await _context.ClientPackageSubscriptions.SingleOrDefaultAsync(m => m.ClientPackageSubscriptionsId == id);
            if (clientPackageSubscriptions == null)
            {
                return NotFound();
            }
            return View(clientPackageSubscriptions);
        }

        // POST: ClientPackageSubscriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientPackageSubscriptionsId,ClientId,PersonalTrainerId,TrainingPackageId")] ClientPackageSubscriptions clientPackageSubscriptions)
        {
            if (id != clientPackageSubscriptions.ClientPackageSubscriptionsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientPackageSubscriptions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientPackageSubscriptionsExists(clientPackageSubscriptions.ClientPackageSubscriptionsId))
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
            return View(clientPackageSubscriptions);
        }

        // GET: ClientPackageSubscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientPackageSubscriptions = await _context.ClientPackageSubscriptions.SingleOrDefaultAsync(m => m.ClientPackageSubscriptionsId == id);
            if (clientPackageSubscriptions == null)
            {
                return NotFound();
            }

            return View(clientPackageSubscriptions);
        }

        // POST: ClientPackageSubscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientPackageSubscriptions = await _context.ClientPackageSubscriptions.SingleOrDefaultAsync(m => m.ClientPackageSubscriptionsId == id);
            _context.ClientPackageSubscriptions.Remove(clientPackageSubscriptions);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ClientPackageSubscriptionsExists(int id)
        {
            return _context.ClientPackageSubscriptions.Any(e => e.ClientPackageSubscriptionsId == id);
        }
    }
}
