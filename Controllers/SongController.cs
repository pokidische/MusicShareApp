using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Constraints;
using MusicShareApp.Data;
using MusicShareApp.Interfaces;
using MusicShareApp.Models;

namespace MusicShareApp.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class SongController : Controller
    {
        private readonly ISongRepository _songRepository;
        private readonly DataContext context;

        public SongController(ISongRepository songRepository, DataContext context)
        {
            _songRepository = songRepository;
            this.context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Song>))]
        public IActionResult GetSongs()
        {
            var GetSongs = _songRepository.GetSongs();

            if (GetSongs == null)
            {
                return NotFound();
            }
            var filePath = Path.Combine("C:/Users/User/Desktop/серьезно/music", "YOUR.mp3");

            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            return File(fileStream, "audio/mp3");
        }
        [HttpPost]
        public IActionResult SetSong(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file");
            }
            var filePath = Path.Combine("C:/Users/User/Desktop/серьезно/music", file.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return Ok("File uploaded successfully");
        }
    }
}
