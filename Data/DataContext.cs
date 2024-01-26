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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Song>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Song>()
                .HasOne(x => x.Playlist)
                .WithMany(x => x.Songs)
                .HasForeignKey(x => x.PlaylistId);

           /* modelBuilder.Entity<Playlist>()
                .HasKey(x => x.Id);*/
        }
    }
}
