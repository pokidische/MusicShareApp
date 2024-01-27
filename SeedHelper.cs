using Microsoft.EntityFrameworkCore;
using MusicShareApp.Data;
using MusicShareApp.Models;

namespace MusicShareApp
{ 
        public static class SeedHelper
        {
        public static WebApplication Seed(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                if (!context.Playlist.Any())
                {
                    var playlists = new List<Playlist>()
                    {
                        new Playlist() {
                            Title = "Your Playlist Title",
                            SongId =  1,
                    PlaylistSongs = new List<Song>() { new Song(){ SongTitle = "YOURS",
                        Album = "YOURS", Artist = "pokidische"  }}
                    }
                };
                    context.Playlist.AddRange(playlists);
                }
                context.SaveChanges();
            }
            return app;
        }
        }   
}
