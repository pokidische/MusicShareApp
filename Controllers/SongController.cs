using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
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
            var songs = _songRepository.GetSongs();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(songs);
        }
    }
}
