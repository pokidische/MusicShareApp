using MusicShareApp.Data;
using MusicShareApp.Interfaces;
using MusicShareApp.Models;

namespace MusicShareApp.Repository
{
    public class SongRepository : ISongRepository
    {
        private readonly DataContext _context;
        public SongRepository(DataContext context)
        {
        _context = context;
        }

        public ICollection<Song> GetSongs() 
        {
            return _context.Song.OrderBy(x => x.Id).ToList();
        }
    }
}
