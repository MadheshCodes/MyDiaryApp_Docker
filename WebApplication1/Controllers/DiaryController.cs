using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class DiaryController : Controller
    {

        private readonly AppDbContext _context;
        public DiaryController(AppDbContext context) => _context = context;


        // GET: /Diary/Diary
        [HttpGet]
        public async Task<IActionResult> Diary()
        {
            var entries = await _context.Diaries
                .OrderByDescending(d => d.EntryDate)
                .ToListAsync();
            return View(entries);
        }



        // POST: /Diary/Diary
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Diary([Bind("Content")] Diary input)
        {
            if (!ModelState.IsValid)
            {
                // return list + show validation errors
                var existing = await _context.Diaries.OrderByDescending(d => d.EntryDate).ToListAsync();
                return View(existing);
            }

            var diary = new Diary
            {
                EntryDate = DateTime.UtcNow,
                Content = input.Content ?? string.Empty,
            };

            _context.Diaries.Add(diary);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Diary)); // Post-Redirect-Get
        }


    }


}
