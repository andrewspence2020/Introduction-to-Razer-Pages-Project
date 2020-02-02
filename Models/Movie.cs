using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazar.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MovieName { get; set; }
        public string Director { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
    }
}
