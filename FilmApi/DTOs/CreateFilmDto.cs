using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmApi.DTOs
{
    public class CreateFilmDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Raiting { get; set; }
    }
}
