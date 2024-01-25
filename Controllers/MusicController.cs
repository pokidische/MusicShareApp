using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicShareApp.Data;
using MusicShareApp.Models;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/music")]
public class MusicController : ControllerBase
{
    private readonly DataContext _context;

    public MusicController(DataContext context)
    {
        _context = context;
    }

    // Добавьте методы для работы с музыкой

    [HttpGet("playlists")]
    public ActionResult<IEnumerable<Playlist>> GetPlaylists()
    {
        var playlists = _context.Playlists.Include(p => p.Song).ToList();
        return Ok(playlists);
    }

    [HttpGet("playlists/{id}")]
    public ActionResult<Playlist> GetPlaylistById(int id)
    {
        var playlist = _context.Playlists.Include(p => p.Song).FirstOrDefault(p => p.playlistId == id);

        if (playlist == null)
        {
            return NotFound();
        }

        return Ok(playlist);
    }

    [HttpPost("playlists")]
    public ActionResult<Playlist> AddPlaylist(Playlist playlist)
    {
        _context.Playlists.Add(playlist);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetPlaylistById), new { id = playlist.playlistId }, playlist);
    }

    [HttpPost("playlists/{playlistId}/songs")]
    public ActionResult<Song> AddSongToPlaylist(int playlistId, Song song)
    {
        var playlist = _context.Playlists.Include(p => p.Song).FirstOrDefault(p => p.playlistId == playlistId);

        if (playlist == null)
        {
            return NotFound("Playlist not found");
        }

        playlist.Songs.Add(song);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetPlaylistById), new { id = playlist.playlistId }, playlist);
    }

    // Добавьте другие методы, такие как Update и Delete, по мере необходимости.
}
