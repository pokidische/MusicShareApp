using Microsoft.EntityFrameworkCore;
using MusicShareApp.Models;

namespace MusicShareApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<Song> Song { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Song>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Song>()
                .HasOne(x => x.Playlist)
                .WithMany(x => x.PlaylistSongs)
                .HasForeignKey(x => x.PlaylistId);

            modelBuilder.Entity<Playlist>()
                .HasKey(x => x.Id);
        }
    }
}
