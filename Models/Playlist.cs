namespace MusicShareApp.Models
{
    public class Playlist
    {
        public int playlistId { get; set; }
        public string Title { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
