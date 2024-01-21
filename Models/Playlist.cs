namespace MusicShareApp.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
        public Song Song { get; set;} 
    }
}
