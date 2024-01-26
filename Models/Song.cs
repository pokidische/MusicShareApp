
namespace MusicShareApp.Models
{
    public class Song
    {
      public int Id { get; set; }
      public string songTitle { get; set; }
      public string Artist { get; set; }
      public string Album { get; set; }
      public ICollection<Playlist> Playlists { get; set;}
    }   
}
