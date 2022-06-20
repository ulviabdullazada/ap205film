using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmApi.DTOs
{
    public class UpdateFilmDto
    {
        public string Name { get; set; }
        public double? Raiting { get; set; }
    }
}
