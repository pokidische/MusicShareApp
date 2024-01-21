using Microsoft.EntityFrameworkCore;
using MusicShareApp.Models;

namespace MusicShareApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        
        }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song > Songs { get; set; }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>()
                .HasKey(pc => new { pc.playlistId, pc.songId });
        }*/

    }
}
