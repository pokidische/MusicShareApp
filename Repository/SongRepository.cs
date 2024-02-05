using MusicShareApp.Data;
using MusicShareApp.Interfaces;
using MusicShareApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicShareApp.Repository
{
    public class SongRepository : ISongRepository
    {
        private readonly DataContext _context;

        public SongRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Song> GetSong()
        {
            return _context.Song.ToList();
        }

        public ICollection<Song> SetSong()
        {
            throw new NotImplementedException();
        }
    }
}
