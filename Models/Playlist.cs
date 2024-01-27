using Microsoft.EntityFrameworkCore;

namespace MusicShareApp.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public string Title { get; set; }
        public List<Song> PlaylistSongs { get; set; }
    }
}
