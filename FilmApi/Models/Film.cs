using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmApi.Models
{
    public class Film
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Raiting { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
