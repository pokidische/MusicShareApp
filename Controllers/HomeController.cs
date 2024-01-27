using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicShareApp.Data;
using MusicShareApp.Models;
using System;
using System.IO;
using System.Linq;

namespace MusicShareApp.Controllers
{
    [ApiController]
    [Route("api/audio")]
    public class AudioController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AudioController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("playlist/{playlistId}")]
        public IActionResult GetAudioByPlaylistId(int playlistId)
        {
            var playlist = _context.Playlist
                .Include(p => p.PlaylistSongs)
                .FirstOrDefault(p => p.Id == playlistId);

            if (playlist == null)
            {
                return NotFound();
            }

            var audioList = playlist.PlaylistSongs.Select(s => new
            {
                s.SongTitle,
                s.Artist,
                s.Album
            });

            return Ok(audioList);
        }

        [HttpPost("upload")]
        public IActionResult UploadAudio(IFormFile audioFile, [FromForm] Song song)
        {
            if (audioFile == null || audioFile.Length == 0)
            {
                return BadRequest("Audio file is required.");
            }

            if (ModelState.IsValid)
            {
                var uploadFolder = Path.Combine(_webHostEnvironment.ContentRootPath, ":D", "Music");
                var uniqueFileName = $"{Guid.NewGuid()}_{audioFile.FileName}";
                var filePath = Path.Combine(uploadFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    audioFile.CopyTo(stream);
                }

                // Assuming Song object contains information about the music.
                song.AudioFilePath = filePath; // Save the file path in the database.

                _context.Song.Add(song);
                _context.SaveChanges();

                // Generate a link for the client application.
                var link = $"{Request.Scheme}://{Request.Host}/:D/Music/{uniqueFileName}";

                return Ok(new { Link = link });
            }

            return BadRequest(ModelState);
        }
    }
}


