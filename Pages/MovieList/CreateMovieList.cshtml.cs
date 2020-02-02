using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazar
{
    public class CreateMovieListModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateMovieListModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Movie Movie { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Movie.AddAsync(Movie);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }

        }
    }
}