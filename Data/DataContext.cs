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
        public DbSet<Song> Songs { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>()
                .HasKey(ps => new { ps.playlistId, ps.songId });

            modelBuilder.Entity<Playlist>()
                .HasOne(p => p.Song)
                .WithMany(ps => ps.Playlists)
                .HasForeignKey(s => s.songId);
            modelBuilder.Entity<Playlist>()
                .HasOne(p => p.Song)
                .WithOne
        }*/
    }
}
