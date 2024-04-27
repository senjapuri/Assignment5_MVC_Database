using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BloodBank.Data;
using BloodBank.Models;

namespace BloodBank.Controllers
{
    public class BloodBagsController : Controller
    {
        private readonly BloodBankContext _context;

        public BloodBagsController(BloodBankContext context)
        {
            _context = context;
        }

        // GET: BloodBags
        public async Task<IActionResult> Index()
        {
            var bloodBankContext = _context.BloodBag.Include(b => b.Donor).Include(b => b.Recipient);
            return View(await bloodBankContext.ToListAsync());
        }

        // GET: BloodBags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodBag = await _context.BloodBag
                .Include(b => b.Donor)
                .Include(b => b.Recipient)
                .FirstOrDefaultAsync(m => m.BagId == id);
            if (bloodBag == null)
            {
                return NotFound();
            }

            return View(bloodBag);
        }

        // GET: BloodBags/Create
        public IActionResult Create()
        {
            ViewData["DonorId"] = new SelectList(_context.Donor, "DonorId", "DonorId");
            ViewData["RecipientId"] = new SelectList(_context.Recipient, "RecipientId", "RecipientId");
            return View();
        }

        // POST: BloodBags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BagId,DonorId,RecipientId,DonationDate,ExpiryDate,BloodType,Volume")] BloodBag bloodBag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bloodBag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonorId"] = new SelectList(_context.Donor, "DonorId", "DonorId", bloodBag.DonorId);
            ViewData["RecipientId"] = new SelectList(_context.Recipient, "RecipientId", "RecipientId", bloodBag.RecipientId);
            return View(bloodBag);
        }

        // GET: BloodBags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodBag = await _context.BloodBag.FindAsync(id);
            if (bloodBag == null)
            {
                return NotFound();
            }
            ViewData["DonorId"] = new SelectList(_context.Donor, "DonorId", "DonorId", bloodBag.DonorId);
            ViewData["RecipientId"] = new SelectList(_context.Recipient, "RecipientId", "RecipientId", bloodBag.RecipientId);
            return View(bloodBag);
        }

        // POST: BloodBags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BagId,DonorId,RecipientId,DonationDate,ExpiryDate,BloodType,Volume")] BloodBag bloodBag)
        {
            if (id != bloodBag.BagId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloodBag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloodBagExists(bloodBag.BagId))
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
            ViewData["DonorId"] = new SelectList(_context.Donor, "DonorId", "DonorId", bloodBag.DonorId);
            ViewData["RecipientId"] = new SelectList(_context.Recipient, "RecipientId", "RecipientId", bloodBag.RecipientId);
            return View(bloodBag);
        }

        // GET: BloodBags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodBag = await _context.BloodBag
                .Include(b => b.Donor)
                .Include(b => b.Recipient)
                .FirstOrDefaultAsync(m => m.BagId == id);
            if (bloodBag == null)
            {
                return NotFound();
            }

            return View(bloodBag);
        }

        // POST: BloodBags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bloodBag = await _context.BloodBag.FindAsync(id);
            if (bloodBag != null)
            {
                _context.BloodBag.Remove(bloodBag);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloodBagExists(int id)
        {
            return _context.BloodBag.Any(e => e.BagId == id);
        }
    }
}
