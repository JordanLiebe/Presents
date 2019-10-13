using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DubAttendenceTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DubAttendenceTracker.Controllers
{
    public class AttendenceController : Controller
    {
        private readonly DubAttendenceTrackerContext _context;

        public AttendenceController(DubAttendenceTrackerContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            var Event = _context.Event.Find(id);

            ViewData["Event"] = id;

            if (Event == null)
                return NotFound();

            var Connections = await _context.Attendences.Where(s => s.EventId == id).ToListAsync();

            return View(Connections);
        }
        public IActionResult Add(int? id, int Event)
        {
            ViewData["Event"] = Event;

            ViewBag.People = new SelectList(_context.Person, "Id", "FullName");
            ViewBag.Events = new SelectList(_context.Event, "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(int? Event, [Bind("Id, PersonId,EventId")] Attendence attendence)
        {
            if(ModelState.IsValid)
            {
                _context.Attendences.Add(attendence);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = Event });
            }
            return View(attendence);
        }
        public async Task<IActionResult> Delete(int? id, int Event)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["Event"] = Event;

            var attendence = await _context.Attendences
                .FirstOrDefaultAsync(m => m.Id == id);

            if (attendence == null)
            {
                return NotFound();
            }

            return View(attendence);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id, int Event)
        {
            var attendence = await _context.Attendences.FindAsync(id);
            _context.Attendences.Remove(attendence);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = Event });
        }
    }
}