using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazar.Controllers
{
    [Route("api/Movie")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Movie.ToListAsync() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var MovieFromDb = await _db.Movie.FirstOrDefaultAsync(u => u.Id == id);
            if (MovieFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Movie.Remove(MovieFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete succesful" });
        }
    }
}