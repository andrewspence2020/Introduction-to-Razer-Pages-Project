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
    public class MovieListModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public MovieListModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Movie> Movies { get; set; }
        public async Task OnGet()
        {
            Movies = await _db.Movie.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id) 
        {
            var movie = await _db.Movie.FindAsync(id);
            if (movie == null) 
            {
                return NotFound();
            }
            _db.Movie.Remove(movie);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}