using MusicShareApp.Data;
using MusicShareApp.Models;

namespace MusicShareApp
{ 
        public class Seed
        {
            private readonly DataContext dataContext;
            public Seed(DataContext context)
            {
                this.dataContext = context;
            }
            public void SeedDataContext()
            {
                if (!dataContext.Playlists.Any())
                {
                var playlists = new List<Playlist>()
                {
                    new Playlist()
                    {
                        Song = new Song()
                    },
                    new Playlist {Song = new Song(){ songTitle = "YOURS"}}
                };
                    dataContext.Playlists.AddRange(playlists);
                    dataContext.SaveChanges();
                }
            }
        }
    
}
