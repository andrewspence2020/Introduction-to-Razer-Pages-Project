using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazar
{
    public class UpsertMoviesModel : PageModel
    {
        private ApplicationDbContext _db;
        public UpsertMoviesModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Movie = new Movie();
            if (id == null)
            {
                //create
                return Page();
            }
            //update
            Movie = await _db.Movie.FirstOrDefaultAsync(u => u.Id == id);
            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Movie.Id == 0)
                {
                    _db.Movie.Add(Movie);
                }
                else
                {
                    _db.Movie.Update(Movie);
                }
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}