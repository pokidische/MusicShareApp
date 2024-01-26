using Microsoft.EntityFrameworkCore;

namespace MusicShareApp.Models
{
    public class Playlist
    {
        public string playlistId { get; set; }
        public int  songId { get; set; }
        public string Title { get; set; }
        public Song Song { get; set; }
    }
}
