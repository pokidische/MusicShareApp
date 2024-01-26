namespace MusicShareApp.Models
{
    public class Playlist
    {
        public int  songId { get; set; }
        public string Title { get; set; }
        public Song Song { get; set; }
    }
}
