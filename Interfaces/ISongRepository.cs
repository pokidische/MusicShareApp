using MusicShareApp.Models;

namespace MusicShareApp.Interfaces
{
    public interface ISongRepository
    {
        ICollection<Song> GetSongs();
        ICollection<Song> SetSong();
    }
}
