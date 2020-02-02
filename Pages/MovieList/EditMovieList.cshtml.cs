using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazar
{
    public class EditMovieListModel : PageModel
    {
        private ApplicationDbContext _db;
        public EditMovieListModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task OnGet(int id)
        {
            Movie = await _db.Movie.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var MovieFromDb = await _db.Movie.FindAsync(Movie.Id);
                MovieFromDb.MovieName = Movie.MovieName;
                MovieFromDb.Director = Movie.Director;
                MovieFromDb.ReleaseDate = Movie.ReleaseDate;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}