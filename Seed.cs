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
                    var Playlists = new List<Playlist>()
                {
                    new Playlist()
                        {
                            Title = "MY PLAYLIST",
                            Songs = new List<Song>
                            {
                                new Song { songTitle = "YOUR" }
                            }
                        }
                };
                    dataContext.Playlists.AddRange(Playlists);
                    dataContext.SaveChanges();
                }
            }
        }
    
}
