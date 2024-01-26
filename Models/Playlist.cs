using Microsoft.EntityFrameworkCore;

namespace MusicShareApp.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public string Title { get; set; }
        public virtual List<Song> Songs { get; set; }
    }
}
