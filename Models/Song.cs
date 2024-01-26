
namespace MusicShareApp.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string SongTitle { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public int PlaylistId { get; set; }
        public virtual Playlist Playlist { get; set; }
    }
}
