using FilmApi.DAL;
using FilmApi.DTOs;
using FilmApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FilmController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public IActionResult All()
        {
            return Ok(_context.Films.Where(f => f.IsDeleted == false));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Film film = _context.Films.Where(f => f.IsDeleted == false && f.Id == id).FirstOrDefault();
            if (film == null) return StatusCode(StatusCodes.Status404NotFound, new { statusCode = 1055, message = "Film could not found" });
            return Ok(film);
        }
        [HttpPost]
        public IActionResult Create(CreateFilmDto filmDto)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status400BadRequest);
            Film film = new Film {
                Name = filmDto.Name,
                Raiting = filmDto.Raiting,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };
            _context.Films.Add(film);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Film film)
        {
            Film filmDb = _context.Films.Find(id);
            if (filmDb is null) return StatusCode(StatusCodes.Status400BadRequest);
            filmDb.Name = film.Name ?? filmDb.Name;
            filmDb.Raiting = film.Raiting == 0 ? filmDb.Raiting : film.Raiting;
            _context.SaveChanges();
            return Ok(filmDb);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Film film = _context.Films.Find(id);
            if (film is null) return StatusCode(StatusCodes.Status404NotFound);
            _context.Films.Remove(film);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
