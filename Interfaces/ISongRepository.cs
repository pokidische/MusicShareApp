using Microsoft.EntityFrameworkCore;
using MusicShareApp.Models;

namespace MusicShareApp.Interfaces
{
    public interface ISongRepository
    {
        ICollection<Song> GetSong();
        ICollection<Song> SetSong();

    }
}
